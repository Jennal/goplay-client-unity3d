using System;
using GoPlay.Encode.Interface;
using GoPlay.Transfer;
using GoPlay.Package;
using GoPlay.Service.Processor;
using GoPlay.Helper;
using GoPlay.Service.HandShake;
using GoPlay.Service.HeartBeat;
using GoPlay.Service.Ping;
using GoPlay.Event;
using GoPlay.Encode.Factory;

namespace GoPlay.Service
{
    public class Client<TTransfer, TEncoder> : Client<TTransfer>
        where TTransfer : ITransfer, new()
        where TEncoder : IEncoder, new()
    {
        public Client() : base(new TEncoder().Encoding)
        {
        }
        
        protected void Call<T>(Pack pack, Action<T> callback)
        {
            var ec = new EventCallback(this, callback, typeof(T));
            var encoder = EncoderFactory.Create(pack.Header.Encoding);
            ec.Call(encoder, pack.Data);
        }

        protected bool CheckDataType<T>()
        {
            return m_encoder.IsProperType<T>();
        }

        #region Request

        public void Request<T, RT>(string route, T data, Action<RT> succCallback, Action<ErrorMessage> failedCallback)
        {
            if (!CheckDataType<T>()) throw new Exception(string.Format("Request: wrong data type, can't be encoded with {0}", m_encoder.Encoding));
            if (!CheckDataType<RT>()) throw new Exception(string.Format("Request: wrong success callback data type, can't be encoded with {0}", m_encoder.Encoding));

            var buffer = m_encoder.Encode(data);
            base.Request(route, buffer, (Pack pack) =>
            {
                Call(pack, succCallback);
            }, failedCallback);
        }

        public void Request<RT>(string route, Action<RT> succCallback, Action<ErrorMessage> failedCallback)
        {
            if (!CheckDataType<RT>()) throw new Exception(string.Format("Request: wrong success callback data type, can't be encoded with {0}", m_encoder.Encoding));

            base.Request(route, (Pack pack) =>
            {
                Call(pack, succCallback);
            }, failedCallback);
        }

        public void Notify<T>(string route, T data)
        {
            if (!CheckDataType<T>()) throw new Exception(string.Format("Notify: wrong data type, can't be encoded with {0}", m_encoder.Encoding));

            var buffer = m_encoder.Encode(data);
            base.Notify(route, buffer);
        }

        #region Push
        public void On<RT, T>(string evt, RT recvObj, Action<T> callback)
        {
            if (!CheckDataType<T>()) throw new Exception(string.Format("On: wrong callback data type, can't be encoded with {0}", m_encoder.Encoding));

            base.On(evt, recvObj, (Pack pack) =>
            {
                Call(pack, callback);
            });
        }

        public void Off<RT>(string evt, RT recvObj)
        {
            base.Off(evt, recvObj);
        }

        public void Once<RT, T>(string evt, RT recvObj, Action<T> callback)
        {
            if (!CheckDataType<T>()) throw new Exception(string.Format("Once: wrong callback data type, can't be encoded with {0}", m_encoder.Encoding));

            base.Once(evt, recvObj, (Pack pack) =>
            {
                Call(pack, callback);
            });
        }
        #endregion
        #endregion
    }
}

