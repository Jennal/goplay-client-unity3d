using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Config
{
    public static class Consts
    {
        public const string ClientVersion = "0.0.1";
        public const string ClientType = "GoPlay-Client-Unity3d/C#";

        public const int HeartBeatRate = 15000; //millisecond
        public const int HeartBeatTimeOut = 3000; //millisecond
        public const int HeartBeatMaxLostTimes = 3;
    }
}
