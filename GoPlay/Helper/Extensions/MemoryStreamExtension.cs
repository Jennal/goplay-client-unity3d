using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoPlay.Helper.Extensions
{
    public static class MemoryStreamExtension
    {
        public static void ClearRead(this MemoryStream ms)
        {
            if (ms.Position != ms.Length) return;
            ms.Clear();
        }

        public static void Clear(this MemoryStream ms)
        {
            byte[] buffer = ms.GetBuffer();
            Array.Clear(buffer, 0, buffer.Length);
            ms.Position = 0;
            ms.SetLength(0);
        }
    }
}
