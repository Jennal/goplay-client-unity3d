using System;
using System.Text;
using GoPlay.Encode.Factory;
using GoPlay.Encode.Interface;
using GoPlay.Package;
using Newtonsoft.Json;

namespace GoPlay.Encode.Json
{
    public class JsonEncoder : IEncoder
    {
        static JsonEncoder() {
            EncoderFactory.Regist(EncodingType.ENCODING_JSON, new JsonEncoder());
        }

		public EncodingType Encoding {
			get {
				return EncodingType.ENCODING_JSON;
			}
		}

        public T Decode<T>(byte[] buffer)
        {
            var json = System.Text.Encoding.UTF8.GetString(buffer);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public byte[] Encode<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }
    }
}