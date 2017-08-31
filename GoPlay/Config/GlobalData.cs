using GoPlay.Encode.Factory;
using GoPlay.Encode.Interface;
using GoPlay.Helper;
using GoPlay.Package;
using System;
using System.Collections.Generic;

namespace GoPlay.Config
{
    internal class HandShakeSaveData
    {
        public string DictMd5;
        public Dictionary<string, UInt16> Routes;
    }

    public interface GlobalDataSaveDelegate
    {
        byte[] Load();
        void Save(byte[] data);
    }

    public static class GlobalHandShakeData
    {
        private static HandShakeResponse m_handShakeResponse;
        private static HandShakeSaveData m_handShakeSaveData;

        private static TimeSpan m_serverTimeSpan = new TimeSpan();

        private static IEncoder m_encoder = EncoderFactory.Create(EncodingType.ENCODING_JSON);

        public static GlobalDataSaveDelegate GlobalDataSaveDelegate = null;
        
        public static string GetDictMd5()
        {
            if(m_handShakeSaveData == null) return "";

            return m_handShakeSaveData.DictMd5;
        }

        public static string GetStringRoute(UInt16 route)
        {
            if (m_handShakeSaveData == null) return "";

            foreach (var item in m_handShakeSaveData.Routes)
            {
                if (item.Value == route) return item.Key;
            }

            return "";
        }

        public static UInt16 GetIndexRoute(string route)
        {
            if (m_handShakeSaveData == null) return Header.ROUTE_INDEX_NONE;
            if (!m_handShakeSaveData.Routes.ContainsKey(route)) return Header.ROUTE_INDEX_NONE;

            return m_handShakeSaveData.Routes[route];
        }

        public static int GetHeartBeatRate()
        {
            if (m_handShakeResponse == null) return Consts.HeartBeatRate;
            return m_handShakeResponse.HeartBeatRate;
        }

        public static int GetHeartBeatTimeOut()
        {
            return Consts.HeartBeatTimeOut;
        }

        public static int GetHeartBeatMaxLostTimes()
        {
            return Consts.HeartBeatMaxLostTimes;
        }

        public static DateTime GetServerTime()
        {
            var now = DateTime.Now;
            now.Add(m_serverTimeSpan);
            return now;
        }

        public static void LoadData()
        {
            if (GlobalDataSaveDelegate == null) return;

            var data = GlobalDataSaveDelegate.Load();
            m_handShakeSaveData = m_encoder.Decode<HandShakeSaveData>(data);
        }

        public static void SaveData()
        {
            if (GlobalDataSaveDelegate == null) return;

            var data = m_encoder.Encode(m_handShakeSaveData);
            GlobalDataSaveDelegate.Save(data);
        }

        public static void Update(HandShakeResponse resp, IEncoder encoder)
        {
            m_handShakeResponse = resp;
            m_serverTimeSpan = m_handShakeResponse.Now.Subtract(DateTime.Now);
            updateSaveData(encoder);
        }

        private static void updateSaveData(IEncoder encoder)
        {
            if (m_handShakeResponse.Routes == null) return;

            m_handShakeSaveData = new HandShakeSaveData
            {
                Routes = m_handShakeResponse.Routes
            };
            m_handShakeSaveData.DictMd5 = Md5Helper.Md5(encoder, m_handShakeSaveData.Routes);

            SaveData();
        }
    }
}
