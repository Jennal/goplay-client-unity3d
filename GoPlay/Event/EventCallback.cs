using System;
using GoPlay.Encode.Interface;

namespace GoPlay.Event
{
    public class EventCallback
    {
        public object Reciever { get; }
        public object Callback { get; }
        public Type CallbackParamType { get; }

        public EventCallback(object recvObj, object cb, Type t) {
            Reciever = recvObj;
            Callback = cb;
            CallbackParamType = t;
        }

        public void Call(object data) {
            var actionType = typeof(Action<>).MakeGenericType(CallbackParamType);
            actionType
                .GetMethod("Invoke")
                .Invoke(Callback, new object[] { data });
        }

        public void Call(IEncoder encoder, byte[] data) {
			var encoderType = encoder.GetType();
			var typeData = encoderType
                    .GetMethod("Decode")
                    .MakeGenericMethod(CallbackParamType)
                    .Invoke(encoder, new object[] { data });
            var actionType = typeof(Action<>).MakeGenericType(CallbackParamType);
            actionType
                .GetMethod("Invoke")
                .Invoke(Callback, new object[] { typeData });
        }
    }
}