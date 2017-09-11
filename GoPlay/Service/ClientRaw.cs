using GoPlay.Config;
using GoPlay.Encode.Factory;
using GoPlay.Encode.Interface;
using GoPlay.Helper;
using GoPlay.Package;
using GoPlay.Service.HandShake;
using GoPlay.Service.HeartBeat;
using GoPlay.Service.Ping;
using GoPlay.Service.Processor;
using GoPlay.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Service
{
    public class Client<TTransfer>
        where TTransfer : ITransfer, new()
    {
        protected TTransfer m_transfer = new TTransfer();
        protected IEncoder m_encoder;

        protected SendProcessor m_sendProcessor;
        protected RecvProcessor m_recvProcessor;
        protected HandShakeManager m_handShakeManager;
        protected HeartBeatManager m_heartBeatManager;

        protected bool m_isHandShaked = false;
        public bool Connected
        {
            get
            {
                return m_transfer.Connected && m_isHandShaked;
            }
        }
        public int AveragePing
        {
            get
            {
                return PingCalculator.Default.AveragePing;
            }
        }
        public int LastPing
        {
            get
            {
                return PingCalculator.Default.LastPing;
            }
        }

        public event Action<ITransfer> OnConnected;
        public event Action<ITransfer> OnDisconnected;
        public event Action<Exception> OnError;

        public Client(EncodingType e)
        {
            m_encoder = EncoderFactory.Create(e);

            m_sendProcessor = new SendProcessor(m_transfer, m_encoder);
            m_handShakeManager = new HandShakeManager(m_sendProcessor);
            m_heartBeatManager = new HeartBeatManager(m_sendProcessor);
            m_recvProcessor = new RecvProcessor(m_sendProcessor, m_handShakeManager, m_heartBeatManager, m_transfer);

            m_transfer.OnConnected += HandleConnected;
            m_transfer.OnDisconnected += HandleDisconnected;
            m_transfer.OnError += HandleError;
        }

        protected virtual void OnConnectedEvent(ITransfer transfer)
        {
            if (OnConnected == null) return;
            OnConnected(transfer);
        }

        protected virtual void OnDisconnectedEvent(ITransfer transfer)
        {
            if (OnDisconnected == null) return;
            OnDisconnected(transfer);
        }

        protected virtual void OnErrorEvent(Exception err)
        {
            if (OnError == null) return;
            OnError(err);
        }

        protected void HandleConnected(ITransfer transfer)
        {
            m_handShakeManager.Send(() =>
            {
                m_isHandShaked = true;
                m_heartBeatManager.Start();

                var reconnectTo = GlobalHandShakeData.GetReconnectTo();
                if (reconnectTo != null)
                {
                    //reconnect
                    Disconnect();
                    Connect(reconnectTo.Host, reconnectTo.Port);
                }

                Debug.Log("OnConnected");
                OnConnectedEvent(transfer);
            });

            m_sendProcessor.Start();
            m_recvProcessor.Start();
        }
        protected void HandleDisconnected(ITransfer obj)
        {
            m_isHandShaked = false;
            Debug.Log("OnDisconnected");
            m_heartBeatManager.Reset();
            m_sendProcessor.Reset();
            m_recvProcessor.Reset();

            OnDisconnectedEvent(obj);
        }
        
        protected void HandleError(Exception obj)
        {
            OnErrorEvent(obj);
        }

        #region Connection
        public void Connect(string host, int port)
        {
            m_transfer.Connect(host, port);
        }

        public void Disconnect()
        {
            m_transfer.Disconnect();
        }
        #endregion

        #region Request
        protected virtual Action<T> getMainThreadAction<T>(Action<T> action)
        {
            return action;
        }

        public void Request(string route, byte[] data, Action<Pack> succCallback, Action<ErrorMessage> failedCallback)
        {
            var pack = m_sendProcessor.CreatePackRaw(route, data, PackageType.PKG_REQUEST, m_encoder.Encoding);
            var id = pack.Header.ID;
            m_recvProcessor.RegistRequestCallbackRaw(id, getMainThreadAction(succCallback), getMainThreadAction(failedCallback));

            m_sendProcessor.Send(pack);
        }

        public void Request(string route, Action<Pack> succCallback, Action<ErrorMessage> failedCallback)
        {
            Request(route, null, succCallback, failedCallback);
        }

        public void Notify(string route, byte[] data)
        {
            var pack = m_sendProcessor.CreatePackRaw(route, data, PackageType.PKG_NOTIFY, m_encoder.Encoding);
            m_sendProcessor.Send(pack);
        }

        public void Notify(string route)
        {
            Notify(route, null);
        }

        #region Push
        public void On(string evt, object recvObj, Action<Pack> callback)
        {
            m_recvProcessor.OnRaw(evt, recvObj, getMainThreadAction(callback));
        }

        public void Off(string evt, object recvObj)
        {
            m_recvProcessor.Off(evt, recvObj);
        }

        public void Once(string evt, object recvObj, Action<Pack> callback)
        {
            m_recvProcessor.OnceRaw(evt, recvObj, getMainThreadAction(callback));
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
