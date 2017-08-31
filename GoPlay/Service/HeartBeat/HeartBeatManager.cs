using GoPlay.Config;
using GoPlay.Helper;
using GoPlay.Package;
using GoPlay.Service.Ping;
using GoPlay.Service.Processor;
using System;
using System.Timers;

namespace GoPlay.Service.HeartBeat
{
    public class HeartBeatManager
    {
        private Timer m_timer = new Timer();
        private SendProcessor m_sendProcessor;
        private PingCalculator m_pingCalculator = new PingCalculator();

        public int AveragePing => m_pingCalculator.AveragePing;
        public int LastPing => m_pingCalculator.LastPing;

        public event Action OnTimeOut;

        public HeartBeatManager(SendProcessor sendProcessor)
        {
            m_sendProcessor = sendProcessor;
            m_timer.Elapsed += M_timer_Elapsed;
        }

        private void M_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var pack = new HeartBeatPack();
            m_sendProcessor.Send(pack);
            m_pingCalculator.Send(pack.Header.ID);
        }

        public void Recv(Pack pack)
        {
            m_pingCalculator.Recv(pack.Header.ID);
            //Debug.Log(m_pingCalculator.ToString());
            if(m_pingCalculator.LostCount > GlobalHandShakeData.GetHeartBeatMaxLostTimes())
            {
                OnTimeOut?.Invoke();
            }
        }

        public void Start()
        {
            m_timer.Interval = GlobalHandShakeData.GetHeartBeatRate();
            m_timer.Start();
        }

        public void Reset()
        {
            m_timer.Stop();
            m_pingCalculator.Clear();
        }
    }
}
