using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace GoPlay.Service.Ping.Tests
{
    [TestClass()]
    public class PingCalculatorTests
    {
        [TestMethod()]
        public void PingCalculatorTest()
        {
            var ping = new PingCalculator();
            for (ushort i = 0; i < 10; i++)
            {
                ping.Send(i);
                ping.Recv(i);
            }
            Assert.IsTrue(ping.LastPing < 100);
            Assert.IsTrue(ping.AveragePing < 100);
            Assert.AreEqual(0, ping.LostCount);
        }

        [TestMethod()]
        public void Fail2TimesTest()
        {
            var ping = new PingCalculator();
            for (ushort i = 0; i < 2; i++)
            {
                ping.Send(i);
                Thread.Sleep(3500);
                ping.Recv(i);
            }
            Assert.IsTrue(ping.LastPing >= PingCalculator.LOST_PING);
            Assert.IsTrue(ping.AveragePing >= PingCalculator.LOST_PING);
            Assert.AreEqual(2, ping.LostCount);
        }

        [TestMethod()]
        public void Fail3TimesTest()
        {
            var ping = new PingCalculator();
            for (ushort i = 0; i < 3; i++)
            {
                ping.Send(i);
                Thread.Sleep(3500);
                ping.Recv(i);
            }
            Assert.IsTrue(ping.LastPing >= PingCalculator.LOST_PING);
            Assert.IsTrue(ping.AveragePing >= PingCalculator.LOST_PING);
            Assert.AreEqual(3, ping.LostCount);
        }
    }
}