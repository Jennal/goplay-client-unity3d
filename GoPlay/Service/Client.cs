using System;
using GoPlay.Encode.Interface;
using GoPlay.Transfer;
using GoPlay.Package;
using GoPlay.Service.Processor;
using GoPlay.Helper;

namespace GoPlay.Service
{
	public class Client<TTransfer, TEncoder>
		where TTransfer : ITransfer, new()
		where TEncoder : IEncoder, new()
	{
		private TTransfer m_transfer = new TTransfer();
		private TEncoder m_encoder = new TEncoder();

		private SendProcessor m_sendProcessor;
		private RecvProcessor m_recvProcessor;

		public event Action<ITransfer> OnConnected {
			add {
				m_transfer.OnConnected += value;
			}
			remove {
				m_transfer.OnConnected -= value;
			}
		}

		public event Action<ITransfer> OnDisconnected {
			add {
				m_transfer.OnDisconnected += value;
			}
			remove {
				m_transfer.OnDisconnected -= value;
			}
		}

		public event Action<Exception> OnError {
			add {
				m_transfer.OnError += value;
			}
			remove {
				m_transfer.OnError -= value;
			}
		}

		public Client()
		{
			m_sendProcessor = new SendProcessor(m_transfer, m_encoder);
			m_recvProcessor = new RecvProcessor(m_sendProcessor, m_transfer, m_encoder);

			m_transfer.OnConnected += HandleConnected;
			m_transfer.OnDisconnected += HandleDisconnected;
		}

        private void HandleConnected(ITransfer transfer)
        {
			Debug.Log("OnConnected");
            m_sendProcessor.Start();
			m_recvProcessor.Start();
        }
        private void HandleDisconnected(ITransfer obj)
        {
			Debug.Log("OnDisconnected");
			m_sendProcessor.Reset();
			m_recvProcessor.Reset();
        }

        #region Connection
        public void Connect(string host, int port) {
			m_transfer.Connect(host, port);
		}

		public void Disconnect() {
			m_transfer.Disconnect();
		}
		#endregion

		#region Request

		public void Request<T, RT>(string route, T data, Action<RT> succCallback, Action<ErrorMessage> failedCallback) {
			var pack = m_sendProcessor.CreatePack(route, data, PackageType.PKG_REQUEST);
			var id = pack.Header.ID;
			m_recvProcessor.RegistRequestCallback(id, succCallback, failedCallback);

			m_sendProcessor.Send(pack);
		}

		public void Notify<T>(string route, T data) {
			m_sendProcessor.Send(route, data, PackageType.PKG_NOTIFY);
		}

		#region Push
		public void On<RT, T>(string evt, RT recvObj, Action<T> callback) {
			m_recvProcessor.On(evt, recvObj, callback);
        }

        public void Off<RT>(string evt, RT recvObj) {
            m_recvProcessor.Off(evt, recvObj);
        }

        public void Once<RT, T>(string evt, RT recvObj, Action<T> callback) {
            m_recvProcessor.Once(evt, recvObj, callback);
        }
        #endregion
        #endregion

        #region Clear Events
        public void ClearEvents()
        {
            ClearRequestEvents();
            ClearPushEvents();
        }

        public void ClearPushEvents()
        {
            m_recvProcessor.ClearPushEvents();
        }

        public void ClearRequestEvents()
        {
            m_recvProcessor.ClearRequestEvents();
        }
        #endregion
    }
}

