using System.Net.Sockets;
using System.IO;
using System;
using GoPlay.Helper;

namespace GoPlay.Transfer.Tcp {
	public class Tcp : ITransfer {
		public const int TIME_OUT = 8000;
        public const int BUFFER_SIZE = 1024;

        private byte[] m_buffer = new byte[1024];
        
		private TcpClient m_tcpClient = new TcpClient();
		public NetworkStream Stream {
			get {
				return m_tcpClient.GetStream();
			}
		}

		public bool CanRead {
			get {
				return Stream.CanRead;
			}
		}
		public event Action<ITransfer> OnConnected;
		public event Action<ITransfer> OnDisconnected;
		public event Action<Exception> OnError;

		private void OnConnectedEvent(ITransfer transfer) {
			if (OnConnected == null) return;
			OnConnected(transfer);
		}

		private void OnDisconnectedEvent(ITransfer transfer) {
			if (OnDisconnected == null) return;
			OnDisconnected(transfer);
		}

		private void OnErrorEvent(Exception err) {
			if (OnError == null) return;
			OnError(err);
		}

		public bool Connceted { 
			get {
				if (m_tcpClient == null) return false;
				return m_tcpClient.Connected;
			}
		}

		public void Connect(string host, int port) {
            try
            {
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

		public void Disconnect() {
			if(m_tcpClient.Connected) m_tcpClient.Close();
			OnDisconnectedEvent(this);
		}

		public void ReadAsync(Action<byte[]> callback) {
			try
			{

                Stream.BeginRead(m_buffer, 0, BUFFER_SIZE, state =>
                {
                    try
                    {
                        int length = Stream.EndRead(state);
                        if (length > 0)
                        {
                            using (var ms = new MemoryStream()) {
                                ms.Write(m_buffer, 0, length);
                                callback(ms.ToArray());
                            }
                        }
                        else
                        {
                            Disconnect();
                        }

                    }
                    catch (System.Exception err)
                    {
                        OnErrorEvent(err);
                        Disconnect();
                    }
                }, this);
			}
			catch (System.Exception err)
			{
				OnErrorEvent(err);
				Disconnect();
			}
		}

		public void WriteAsync(byte[] buffer) {
			if(buffer == null) return;
			if(buffer.Length == 0) return;

			// DebugHelper.PrintBytes("Write: {0}", buffer);
			try
			{
                Stream.BeginWrite(buffer, 0, buffer.Length, state =>
                {
                    if ( ! Connceted) return;
                    Stream.EndWrite(state);
                }, this);

				return;
			}
			catch (System.Exception err)
			{
				OnErrorEvent(err);
				Disconnect();
			}
			
			return;
		}
	}
}
