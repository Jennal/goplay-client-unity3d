using GoPlay.Encode.Interface;
using System;
using GoPlay.Package;
using Google.Protobuf;
using System.IO;

namespace GoPlay.Encode.Protobuf
{
    public class ProtobufEncoder : IEncoder
    {
        public EncodingType Encoding
        {
            get
            {
                return EncodingType.ENCODING_PROTOBUF;
            }
        }

        public T Decode<T>(byte[] buffer)
        {
            var parserInfo = typeof(T).GetProperty("Parser", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            if (parserInfo == null) throw new Exception("protobuf: convert on wrong type value");

            var parser = parserInfo.GetValue(null, null) as MessageParser;
            if (parser == null) throw new Exception("protobuf: convert on wrong type value");

            return (T)parser.ParseFrom(buffer);
        }

        public byte[] Encode<T>(T data)
        {
            var pb = data as IMessage;
            if(pb == null) throw new Exception("protobuf: convert on wrong type value");

            var ms = new MemoryStream();
            pb.WriteTo(ms);
            return ms.ToArray();
        }
    }
}
