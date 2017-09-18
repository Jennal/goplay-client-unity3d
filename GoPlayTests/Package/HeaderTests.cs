using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoPlay.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GoPlay.Config;
using GoPlay.Encode.Factory;
using GoPlay.Encode.Json;

namespace GoPlay.Package.Tests
{
    [TestClass()]
    public class HeaderTests
    {
        [TestInitialize]
        public void Start()
        {
            GlobalHandShakeData.Update(new HandShakeResponse
            {
                Routes = new Dictionary<string, ushort>
                {
                    { "Hello", 20 },
                }
            }, new JsonEncoder());
        }

        [TestMethod()]
        public void HeaderTest()
        {
            for (int i = 0; i < Header.MAX_ID * 2; i++)
            {
                var header = new Header("");
                Assert.AreEqual(i % (Header.MAX_ID + 1), header.ID);
            }
        }

        [TestMethod()]
        public void HeaderEncodeTest()
        {
            var header = new Header("Hello")
            {
                Type = PackageType.PKG_NOTIFY,
                Encoding = EncodingType.ENCODING_JSON,
                ID = 3,
                Status = Status.Err,
                ContentSize = 10,
            };
            var routeEncoded = header.RouteEncoded;

            foreach (PackageType t in Enum.GetValues(typeof(PackageType)))
            {
                foreach (EncodingType e in Enum.GetValues(typeof(EncodingType)))
                {
                    foreach (Status s in Enum.GetValues(typeof(Status)))
                    {
                        header.Type = t;
                        header.Encoding = e;
                        header.Status = s;
                        if(header.Type == PackageType.PKG_PUSH)
                        {
                            header.RouteEncoded = 0;
                        } else
                        {
                            header.RouteEncoded = routeEncoded;
                        }

                        var buffer = header.GetBytes();
                        using(var ms = new MemoryStream(buffer))
                        {
                            var newHeader = Header.TrySetFromStream(ms);
                            Assert.AreNotEqual(null, newHeader);
                            Assert.AreEqual(header, newHeader);
                        }
                    }
                }
            }
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var header = new Header("Hello")
            {
                Type = PackageType.PKG_NOTIFY,
                Encoding = EncodingType.ENCODING_JSON,
                ID = 3,
                Status = Status.Err,
                ContentSize = 10,
            };
            Assert.AreEqual("Header{ Type: PKG_NOTIFY, Encoding: ENCODING_JSON, ID: 3, Status: STAT_ERR, ContentSize: 10, Route: \"Hello\", RouteEncoded: 20 }", header.ToString());
        }
    }
}