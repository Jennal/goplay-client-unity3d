using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Package
{
    public class HeartBeatPack : Pack
    {
        public HeartBeatPack() : base(new Header(), null)
        {
            Header.Type = PackageType.PKG_HEARTBEAT;
            Header.Route = "";
            Header.RouteEncoded = Header.ROUTE_INDEX_NONE;
        }
    }
}
