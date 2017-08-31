using System;
using GoPlay.Encode.Interface;
using GoPlay.Event;
using GoPlay.Package;
using GoPlay.Transfer;
using GoPlay.Helper;
using System.IO;
using GoPlay.Helper.Extensions;
using GoPlay.Encode.Factory;
using GoPlay.Service.HandShake;
using GoPlay.Service.HeartBeat;
using GoPlay.Service.Ping;

namespace GoPlay.Service.Processor
{
    public class RecvProcessor
    {
        private SendProcessor m_sendProcessor;
        private HandShakeManager m_handShakeManager;
        private HeartBeatManager m_heartBeatManager;
        private ITransfer m_transfer;
        
		private EventDispatcher<byte> m_requestSuccessEventDispatcher = new EventDispatcher<byte>();
		private EventDispatcher<byte> m_requestFailedEventDispatcher = new EventDispatcher<byte>();
		private EventDispatcher<string> m_pushEventDispatcher = new EventDispatcher<string>();

        private bool m_processing = false;
        private MemoryStream m_bufferStream = new MemoryStream();

        public RecvProcessor(SendProcessor sender, HandShakeManager manager, HeartBeatManager hbManager, ITransfer transfer)
        {
            m_sendProcessor = sender;
            m_handShakeManager = manager;
            m_heartBeatManager = hbManager;
            m_transfer = transfer;
        }

        private void recvHeartBeat(Pack pack) {
            pack.Header.Type = PackageType.PKG_HEARTBEAT_RESPONSE;
            m_sendProcessor.Send(pack);
        }

        private void recvHeartBeatResponse(Pack pack) {
            m_heartBeatManager.Recv(pack);
        }

        private void recvPush(Pack pack) {
            var encoder = EncoderFactory.Create(pack.Header.Encoding);
            m_pushEventDispatcher.Emit(pack.Header.Route, encoder, pack.Data);
        }

        private void recvResponse(Pack pack) {
            var encoder = EncoderFactory.Create(pack.Header.Encoding);
            if (pack.Header.Status == Status.STAT_OK) {
                m_requestSuccessEventDispatcher.Emit(pack.Header.ID, encoder, pack.Data);
            } else {
                m_requestFailedEventDispatcher.Emit(pack.Header.ID, encoder, pack.Data);
            }
        }

        private void recvHandShakeResponse(Pack pack)
        {
            m_handShakeManager.Recv(pack);
        }

        private void recvPack(Pack pack) {
            switch (pack.Header.Type) {
                case PackageType.PKG_HEARTBEAT:
                    recvHeartBeat(pack);
                    break;
                case PackageType.PKG_HEARTBEAT_RESPONSE:
                    recvHeartBeatResponse(pack);
                    break;
                case PackageType.PKG_PUSH:
                    recvPush(pack);
                    break;
                case PackageType.PKG_RESPONSE:
                    PingCalculator.Default.Recv(pack.Header.ID);
                    recvResponse(pack);
                    break;
                case PackageType.PKG_HAND_SHAKE_RESPONSE:
                    recvHandShakeResponse(pack);
                    break;
                default:
                    break;
            }
        }

        public void Start() {
            m_processing = true;
            Proc();
        }

        public void Proc() {
            m_transfer.ReadAsync(buffer =>
            {
                var lastPos = m_bufferStream.Position; /* Save Pos */
                //Debug.Log("Position: {0}, Length: {1}", m_bufferStream.Position, m_bufferStream.Length);
                m_bufferStream.Position = m_bufferStream.Length; /* Set Pos to End */
                BinaryWriter bw = new BinaryWriter(m_bufferStream);
                bw.Write(buffer);
                //Debug.Log("Position: {0} => {1}", lastPos, m_bufferStream.Position);
                m_bufferStream.Position = lastPos; /* Restore Pos */
                //Debug.Log("Write-0: {0} => {1}", m_bufferStream.Length, m_bufferStream.Position);

                lastPos = m_bufferStream.Position; /* Save Pos */
                var header = Header.TrySetFromStream(m_bufferStream);
                while (header != null)
                {
                    byte[] data = null;
                    //Debug.Log(" => Header: " + header.ToString());
                    if (header.ContentSize > 0)
                    {
                        if ((m_bufferStream.Length - m_bufferStream.Position) >= header.ContentSize)
                        {
                            //Debug.Log("--------------------");
                            BinaryReader br = new BinaryReader(m_bufferStream);
                            data = br.ReadBytes(header.ContentSize);
                        } else
                        {
                            //Debug.Log("+++++++++++++++++");
                            m_bufferStream.Position = lastPos; /* Restore Pos */
                            if (m_processing) Proc();
                            return;
                        }
                        // DebugHelper.PrintBytes(" => Body: {0}", buffer);
                    }
                    //Debug.Log("Write-1: {0} => {1}", m_bufferStream.Length, m_bufferStream.Position);
                    m_bufferStream.ClearRead();
                    //Debug.Log("Write-2: {0} => {1}", m_bufferStream.Length, m_bufferStream.Position);
                    recvPack(new Pack(header, data));
                    header = Header.TrySetFromStream(m_bufferStream);
                }

                if(m_processing) Proc();
            });
        }

        public void Reset() {
            m_processing = false;
            //ClearEvents();
        }

        public void ClearEvents()
        {
            ClearRequestEvents();
            ClearPushEvents();
        }

        public void ClearPushEvents()
        {
            m_pushEventDispatcher.Clear();
        }

        public void ClearRequestEvents()
        {
            m_requestSuccessEventDispatcher.Clear();
            m_requestFailedEventDispatcher.Clear();
        }

        public void RegistRequestCallback<RT>(byte id, Action<RT> succCallback, Action<ErrorMessage> failedCallback) {
            m_requestSuccessEventDispatcher.Once(id, this, (RT o) => {
				m_requestFailedEventDispatcher.Off(id, this);
				succCallback(o);
			});
			m_requestFailedEventDispatcher.Once(id, this, (ErrorMessage o) => {
				m_requestSuccessEventDispatcher.Off(id, this);
				failedCallback(o);
			});
        }

        public void On<RT, T>(string evt, RT recvObj, Action<T> callback) {
			m_pushEventDispatcher.On(evt, recvObj, callback);
        }

        public void Off<RT>(string evt, RT recvObj) {
            m_pushEventDispatcher.Off(evt, recvObj);
        }

        public void Once<RT, T>(string evt, RT recvObj, Action<T> callback) {
            m_pushEventDispatcher.Once(evt, recvObj, callback);
        }
    }
}