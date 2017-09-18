using GoPlay.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Package
{
    public class HandShakeHeader : Header
    {
        public HandShakeHeader(string route) : base(route)
        {
            Type = PackageType.PKG_HAND_SHAKE;
        }
    }
}
