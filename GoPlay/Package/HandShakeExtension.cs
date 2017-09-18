using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoPlay.Package
{
    public static class HandShakeExtension
    {
        public static DateTime Now(this HandShakeResponse resp)
        {
            return DateTime.Parse(resp.Now);
        }
    }
}
