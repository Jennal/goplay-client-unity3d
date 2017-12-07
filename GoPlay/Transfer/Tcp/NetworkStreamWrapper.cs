using System;
using System.Net.Sockets;

namespace GoPlay.Transfer.Tcp
{
    public class NetworkStreamWrapper : IDisposable
    {
        private NetworkStream m_stream;

        public bool CanRead
        {
            get { return m_stream.CanRead; }
        }

        public int ReadTimeout
        {
            get { return m_stream.ReadTimeout; }
            set { m_stream.ReadTimeout = value; }
        }

        public int WriteTimeout
        {
            get { return m_stream.WriteTimeout; }
            set { m_stream.WriteTimeout = value; }
        }

        private int m_lastReadLength = 0;
        private int m_lastWriteLength = 0;
        private WorkQueue m_readQueue = new WorkQueue();
        private WorkQueue m_writeQueue = new WorkQueue();

        public event Action<Exception> OnError;

        public NetworkStreamWrapper(NetworkStream ns)
        {
            m_stream = ns;
        }

        private void OnErrorEvent(Exception err)
        {
            if (OnError == null) return;
            OnError(err);
        }

        public IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state)
        {
            m_readQueue.Enqueue(() =>
            {
                m_lastReadLength = m_stream.Read(buffer, offset, size);
                callback(null);
            }, OnErrorEvent);

            return null;
        }

        public int EndRead(IAsyncResult state)
        {
            var result = m_lastReadLength;
            m_lastReadLength = 0;
            return result;
        }

        public IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state)
        {
            m_writeQueue.Enqueue(() =>
            {
                m_stream.Write(buffer, offset, size);
                m_lastWriteLength = size;
                callback(null);
            }, OnErrorEvent);

            return null;
        }

        public int EndWrite(IAsyncResult state)
        {
            var result = m_lastWriteLength;
            m_lastWriteLength = 0;
            return result;
        }

        public void Dispose()
        {
            m_readQueue.Stop();
            m_writeQueue.Stop();
        }
    }
}