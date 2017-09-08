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

        #region Request

        public void Request<T, RT>(string route, T data, Action<RT> succCallback, Action<ErrorMessage> failedCallback)
        {
            var buffer = m_encoder.Encode(data);
            base.Request(route, buffer, (Pack pack) =>
            {
                Call(pack, succCallback);
            }, failedCallback);
        }

        public void Request<RT>(string route, Action<RT> succCallback, Action<ErrorMessage> failedCallback)
        {
            base.Request(route, (Pack pack) =>
            {
                Call(pack, succCallback);
            }, failedCallback);
        }

        public void Notify<T>(string route, T data)
        {
            var buffer = m_encoder.Encode(data);
            base.Notify(route, buffer);
        }

        #region Push
        public void On<RT, T>(string evt, RT recvObj, Action<T> callback)
        {
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
            base.Once(evt, recvObj, (Pack pack) =>
            {
                Call(pack, callback);
            });
        }
        #endregion
        #endregion
    }
}

