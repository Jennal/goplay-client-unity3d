using System;
using GoPlay.Encode.Interface;
using GoPlay.Transfer;
using GoPlay.Package;
using GoPlay.Service.Processor;
using GoPlay.Helper;
using GoPlay.Service.HandShake;
using GoPlay.Service.HeartBeat;
using GoPlay.Service.Ping;

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
        private HandShakeManager m_handShakeManager;
        private HeartBeatManager m_heartBeatManager;

        private bool m_isHandShaked = false;
        public bool Connected => m_transfer.Connected && m_isHandShaked;
        public int AveragePing => PingCalculator.Default.AveragePing;
        public int LastPing => PingCalculator.Default.LastPing;

        public event Action<ITransfer> OnConnected;

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
            m_handShakeManager = new HandShakeManager(m_sendProcessor);
            m_heartBeatManager = new HeartBeatManager(m_sendProcessor);
            m_recvProcessor = new RecvProcessor(m_sendProcessor, m_handShakeManager, m_heartBeatManager, m_transfer);

			m_transfer.OnConnected += HandleConnected;
			m_transfer.OnDisconnected += HandleDisconnected;
		}

        private void OnConnectedEvent(ITransfer transfer)
        {
            if (OnConnected == null) return;
            OnConnected(transfer);
        }

        private void HandleConnected(ITransfer transfer)
        {
            m_handShakeManager.Send(() =>
            {
                m_isHandShaked = true;
                m_heartBeatManager.Start();

                Debug.Log("OnConnected");
                OnConnectedEvent(transfer);
            });

            m_sendProcessor.Start();
			m_recvProcessor.Start();
        }
        private void HandleDisconnected(ITransfer obj)
        {
            m_isHandShaked = false;
            Debug.Log("OnDisconnected");
            m_heartBeatManager.Reset();
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

