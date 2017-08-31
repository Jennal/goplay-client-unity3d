using GoPlay.Encode.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GoPlay.Helper
{
    public static class Md5Helper
    {
        public static string Md5(byte[] data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(data);
            return BitConverter.ToString(output).Replace("-", "");
        }

        public static string Md5<T>(IEncoder encoder, T data)
        {
            var buffer = encoder.Encode<T>(data);
            return Md5(buffer);
        }
    }
}
