using System.Collections.Generic;
using GoPlay.Encode.Interface;
using GoPlay.Package;

namespace GoPlay.Encode.Factory
{
    public static class EncoderFactory
    {
        private static Dictionary<EncodingType, IEncoder> s_dict = new Dictionary<EncodingType, IEncoder>();

        public static void Regist(EncodingType encoding, IEncoder encoder) {
            s_dict[encoding] = encoder;
        }
        public static IEncoder Create(EncodingType encoding) {
            if( ! s_dict.ContainsKey(encoding)) return null;
            return s_dict[encoding];
        }
    }
}