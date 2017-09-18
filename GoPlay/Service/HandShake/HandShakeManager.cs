using GoPlay.Config;
using GoPlay.Encode.Factory;
using GoPlay.Package;
using GoPlay.Service.Processor;
using System;

namespace GoPlay.Service.HandShake
{
    public class HandShakeManager
    {
        private Action m_onSuccess = null;
        private SendProcessor m_sendProcessor;

        public HandShakeManager(SendProcessor transfer)
        {
            m_sendProcessor = transfer;
        }

        public void Send(Action onSuccess)
        {
            m_onSuccess = onSuccess;
            m_sendProcessor.Send("", new HandShakeClientData(), PackageType.PKG_HAND_SHAKE);
        }

        public void Recv(Pack pack)
        {
            var encoder = EncoderFactory.Create(pack.Header.Encoding);
            var resp = encoder.Decode<HandShakeResponse>(pack.Data);
            GlobalHandShakeData.Update(resp, EncoderFactory.GetRouteEncoder());

            if (m_onSuccess != null) m_onSuccess.Invoke();
        }
    }
}
