using System.Net.Sockets;
using System.IO;
using System;
using System.Collections;
using GoPlay.Helper;

namespace GoPlay.Transfer.Tcp
{
    public class Tcp : ITransfer
    {
        public const int TIME_OUT = 8000;
        public const int BUFFER_SIZE = 1024;

        private byte[] m_buffer = new byte[1024];

        private string m_connectedHost;
        private int m_connectedPort;

        private TcpClient m_tcpClient;
        public NetworkStream Stream
        {
            get
            {
                return m_tcpClient.GetStream();
            }
        }

        private object m_locker = new object();
        private ArrayList m_buffersBeforeError = ArrayList.Synchronized(new ArrayList());
        //private List<byte[]> m_buffersBeforeError = new List<byte[]>();

        public bool CanRead
        {
            get
            {
                return Stream.CanRead;
            }
        }
        public event Action<ITransfer> OnConnected;
        public event Action<ITransfer> OnDisconnected;
        public event Action<Exception> OnError;

        public Tcp()
        {
        }

        private void OnConnectedEvent(ITransfer transfer)
        {
            if (OnConnected == null) return;
            OnConnected(transfer);
        }

        private void OnDisconnectedEvent(ITransfer transfer)
        {
            if (OnDisconnected == null) return;
            OnDisconnected(transfer);
        }

        private void OnErrorEvent(Exception err)
        {
            if (OnError == null) return;
            OnError(err);
        }

        public bool Connected
        {
            get
            {
                if (m_tcpClient == null) return false;
                return m_tcpClient.Connected;
            }
        }

        public void Connect(string host, int port)
        {
            if (host == m_connectedHost && port == m_connectedPort) return;

            try
            {
                m_connectedHost = host;
                m_connectedPort = port;

                if (m_tcpClient == null) m_tcpClient = new TcpClient();

                m_tcpClient.Connect(host, port);
                Stream.ReadTimeout = TIME_OUT;
                Stream.WriteTimeout = TIME_OUT;
                OnConnectedEvent(this);
            }
            catch (Exception err)
            {
                OnErrorEvent(err);
            }
        }

        public void Disconnect()
        {
            if (!Connected) return;

            m_tcpClient.Close();
            m_tcpClient = null;
            OnDisconnectedEvent(this);
        }

        public void ReadAsync(Action<byte[]> callback)
        {
            try
            {
                if (!Connected) return;

                Stream.BeginRead(m_buffer, 0, BUFFER_SIZE, state =>
                {
                    try
                    {
                        if (!Connected) return;

                        int length = Stream.EndRead(state);
                        if (length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                ms.Write(m_buffer, 0, length);
                                callback(ms.ToArray());
                            }
                        }
                        else
                        {
                            Disconnect();
                        }

                    }
                    catch (Exception err)
                    {
                        OnErrorEvent(err);
                        Disconnect();
                    }
                }, this);
            }
            catch (Exception err)
            {
                OnErrorEvent(err);
                Disconnect();
            }
        }

        public void WriteAsync(byte[] buffer)
        {
            if (buffer == null) return;
            if (buffer.Length == 0) return;

            try
            {
                //m_buffersBeforeError.Add(buffer);
                if (!Connected) return;
                Stream.BeginWrite(buffer, 0, buffer.Length, state =>
                {
                    try
                    {
                        if (!Connected) return;
                        Stream.EndWrite(state);
                        //m_buffersBeforeError.Remove(buffer);
                    }
                    catch (ArgumentException)
                    {
                        //Write error: begin from last connection / end with current connection
                        //just ignore
                    }
                    catch (Exception err)
                    {
                        OnErrorEvent(err);
                        Disconnect();
                    }
                }, this);

                return;
            }
            catch (Exception err)
            {
                OnErrorEvent(err);
                Disconnect();
            }

            return;
        }

        public void ReWriteBufferBeforeError()
        {
            if (m_buffersBeforeError.Count <= 0) return;

            for (int i = m_buffersBeforeError.Count - 1; i >= 0; --i)
            {
                var item = (byte[])m_buffersBeforeError[i];
                WriteAsync(item);
                m_buffersBeforeError.Remove(item);
            }
        }
    }
}
