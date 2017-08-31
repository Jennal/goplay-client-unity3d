using GoPlay.Config;
using GoPlay.Helper;
using System;
using System.Collections.Generic;

namespace GoPlay.Service.Ping
{
    public class PingCalculator
    {
        public const int LOST_PING = 460;
        public static PingCalculator Default = new PingCalculator();

        private object m_locker = new object();
        private Dictionary<UInt16, DateTime> m_dict = new Dictionary<ushort, DateTime>();

        private int m_totalCount = 0;
        private int m_totalRecvCount = 0;

        public int AveragePing { get; internal set; }
        public int LastPing { get; internal set; }
        public int LostCount { get; internal set; }

        public PingCalculator()
        {
            AveragePing = 0;
            LastPing = 0;
            LostCount = 0;
        }

        public void Clear()
        {
            m_dict.Clear();
            AveragePing = 0;
            LastPing = 0;
            LostCount = 0;
        }

        public void Send(UInt16 id)
        {
            lock (m_locker)
            {
                ++m_totalCount;
                m_dict[id] = DateTime.Now;
            }

            DelayCall.Do(GlobalHandShakeData.GetHeartBeatTimeOut(), () =>
            {
                if (!m_dict.ContainsKey(id)) return;

                lock (m_locker)
                {
                    if (!m_dict.ContainsKey(id)) return;
                    m_dict.Remove(id);
                    ++LostCount;
                }
            });
        }

        public void Recv(UInt16 id)
        {
            lock(m_locker)
            {
                ++m_totalRecvCount;
            }

            DateTime now = DateTime.Now;
            DateTime last;

            if (!m_dict.ContainsKey(id))
            {
                updateLastPing(LOST_PING);
                return;
            }
            lock (m_locker)
            {
                if (!m_dict.ContainsKey(id))
                {
                    updateLastPing(LOST_PING);
                    return;
                }

                last = m_dict[id];

                LostCount = 0;
                var timeSpan = now.Subtract(last);
                updateLastPing(timeSpan.Milliseconds);
            }
        }

        private void updateLastPing(int last)
        {
            LastPing = last;
            AveragePing = (int)((double)AveragePing - (double)AveragePing / m_totalCount + (double)LastPing / m_totalCount);

            Debug.Log(ToString());
        }

        public override string ToString()
        {
            return string.Format(@"==============================================
Average Ping: {0} ms
Last Ping:    {1} ms
Continuous Lost Count: {2} ms
Total Send Count: {3}
Total Recv Count: {4}
Lost Rate: {5:0.0}%
==============================================", 
                AveragePing, 
                LastPing, 
                LostCount,
                m_totalCount,
                m_totalRecvCount, 
                (double)((m_totalCount - m_totalRecvCount) / m_totalCount));
        }
    }
}
