using GoPlay.Config;
using GoPlay.Encode.Factory;
using GoPlay.Package;
using GoPlay.Service.Processor;
using GoPlay.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Service.HandShake
{
    public class HandShakeManager
    {
        private Action m_onSuccess = null;
        private SendProcessor m_transfer;

        public HandShakeManager(SendProcessor transfer)
        {
            m_transfer = transfer;
        }

        public void SendRequest(Action onSuccess)
        {
            m_onSuccess = onSuccess;
            m_transfer.Send("", new HandShakeClientData(), PackageType.PKG_HAND_SHAKE);
        }

        public void RecvResponse(Pack pack)
        {
            var encoder = EncoderFactory.Create(pack.Header.Encoding);
            var resp = encoder.Decode<HandShakeResponse>(pack.Data);
            GlobalHandShakeData.Update(resp, encoder);

            if (m_onSuccess != null) m_onSuccess.Invoke();
        }
    }
}
