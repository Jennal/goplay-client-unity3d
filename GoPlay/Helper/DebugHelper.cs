using System;
using System.Text;

namespace GoPlay.Helper
{
    public static class Debug
    {
        public static void Log(string format)
        {
#if UNITY_EDITOR
            Debug.Log(format);
#else
            Console.WriteLine(format);
#endif
        }

        public static void Log(string format, params object[] args)
        {
#if UNITY_EDITOR
            Debug.LogFormat(format, args);
#else
            Console.WriteLine(string.Format(format, args));
#endif
        }

        public static void Error(string format)
        {
#if UNITY_EDITOR
            Debug.LogError(format);
#else
            Console.WriteLine(format);
#endif
        }

        public static void Error(string format, params object[] args)
        {
#if UNITY_EDITOR
            Debug.LogErrorFormat(format, args);
#else
            Console.WriteLine(string.Format(format, args));
#endif
        }

        public static void PrintBytes(byte[] bytes)
        {
            if(bytes == null) {
                Debug.Log("new byte[] == null");
            }

            var sb = new StringBuilder("new byte[] { ");
            for (int i=0; i<bytes.Length; i++)
            {
                var b = bytes[i];
                sb.Append(b);
                if(i != bytes.Length - 1) sb.Append(", ");
            }
            sb.Append("}");
            Debug.Log(sb.ToString());
        }

        public static void PrintBytes(string format, byte[] bytes)
        {
			if(bytes == null) {
				Debug.Log(format, "new byte[] == null");
			}

            var sb = new StringBuilder("new byte[] { ");
            for (int i=0; i<bytes.Length; i++)
            {
                var b = bytes[i];
                sb.Append(b);
                if(i != bytes.Length - 1) sb.Append(", ");
            }
            sb.Append("}");
            Debug.Log(format, sb.ToString());
        }
    }
}