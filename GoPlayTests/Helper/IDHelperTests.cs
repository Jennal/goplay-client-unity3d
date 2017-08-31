using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoPlay.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPlay.Helper.Tests
{
    [TestClass()]
    public class IDHelperTests
    {
        [TestMethod()]
        public void IDHelperTest()
        {
            var id = new IDHelper(10);
            Assert.AreEqual(10, id.Max);
        }

        [TestMethod()]
        public void NextTest()
        {
            var id = new IDHelper(10);
            for (int i = 0; i < 20; i++)
            {
                Assert.AreEqual(i % 11, id.Next());
            }
        }
    }
}