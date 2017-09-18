using System;
using GoPlay.Encode.Interface;
using GoPlay.Package;
using GoPlay.Transfer;
using System.IO;
using System.Collections.Generic;
using GoPlay.Service.Ping;

namespace GoPlay.Service.Processor
{
    public class SendProcessor
    {
        private ITransfer m_transfer;
        private IEncoder m_encoder;
        
        public SendProcessor(ITransfer transfer, IEncoder encoder)
        {
            m_transfer = transfer;
            m_encoder = encoder;
        }
        
        internal Pack CreatePackRaw(string route, byte[] buffer, PackageType t, EncodingType e)
        {
            if (buffer != null && buffer.Length > UInt16.MaxValue)
            {
                throw new Exception(string.Format("data size exceed max length: {0} > {1}", buffer.Length, UInt16.MaxValue));
            }

            var header = new Header(route)
            {
                Type = t,
                Encoding = e,
                Status = Status.Ok,
                ContentSize = buffer != null ? (UInt16)buffer.Length : (UInt16)0,
            };

            return new Pack(header, buffer);
        }

        public Pack CreatePack<T>(string route, T data, PackageType t)
        {
            var buffer = m_encoder.Encode(data);
            return CreatePackRaw(route, buffer, t, m_encoder.Encoding);
        }

        public void Send<T>(string route, T data, PackageType t)
        {
            var pack = CreatePack(route, data, t);
            Send(pack);
        }
        
        public void Send(Pack pack)
        {
            // Debug.LogFormat(" <= Header: {0}", header.ToString());
            // if(buffer != null && buffer.Length > 0) DebugHelper.PrintBytes(" <= Body: {0}", buffer);
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(pack.Header.GetBytes());
                    if(pack.Data != null) bw.Write(pack.Data);

                    m_transfer.WriteAsync(ms.ToArray());

                    if(pack.Header.Type == PackageType.PKG_REQUEST)
                    {
                        PingCalculator.Default.Send(pack.Header.ID);
                    }
                }
            }
        }

        public void Start()
        {
        }

        public void Reset()
        {
        }
    }
}