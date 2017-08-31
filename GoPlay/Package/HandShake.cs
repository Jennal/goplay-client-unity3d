using GoPlay.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Package
{
    public class HandShakeClientData
    {
        public string ClientType;
        public string ClientVersion;
        public string DictMd5;

        public HandShakeClientData()
        {
            ClientType = Consts.ClientType;
            ClientVersion = Consts.ClientVersion;
            DictMd5 = GlobalHandShakeData.GetDictMd5();
        }
    }

    public class HandShakeResponse
    {
        public string ServerVersion;
        public DateTime Now;
        public int HeartBeatRate;
        public Dictionary<string, UInt16> Routes;
    }

    public class HandShakeHeader : Header
    {
        public HandShakeHeader(string route) : base(route)
        {
            Type = PackageType.PKG_HAND_SHAKE;
        }
    }
}
