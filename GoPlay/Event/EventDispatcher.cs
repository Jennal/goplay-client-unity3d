using System;
using System.Collections.Generic;
using GoPlay.Encode.Interface;

namespace GoPlay.Event
{
    public class EventDispatcher<TEventName>
    {
        private object m_locker = new object();
        private Dictionary<TEventName, List<EventCallback>> m_callbacks = new Dictionary<TEventName, List<EventCallback>>();

        public void On<RT, T>(TEventName evt, RT recvObj, Action<T> callback) {
            lock(m_locker) {
                if ( ! m_callbacks.ContainsKey(evt))
                {
                    m_callbacks[evt] = new List<EventCallback>();
                }

                m_callbacks[evt].Add(new EventCallback(recvObj, callback, typeof(T)));
            }
        }

        public void Off<RT>(TEventName evt, RT recvObj) {
            lock(m_locker) {
                if( ! m_callbacks.ContainsKey(evt)) return;
                var list = m_callbacks[evt];

                for(int i=list.Count-1; i>=0; i--)
                {
                    var item = list[i];
                    if(Comparer<RT>.Equals(item.Reciever, recvObj)) {
                        list.RemoveAt(i);
                    }
                }
            }
        }

        public void Once<RT, T>(TEventName evt, RT recvObj, Action<T> callback) {
            On<RT, T>(evt, recvObj, o => {
                Off(evt, recvObj);
                callback(o);
            });
        }

        public void Emit<T>(TEventName evt, T data) {
            EventCallback[] list;
            lock(m_locker) {
                if( ! m_callbacks.ContainsKey(evt)) return;
				list = m_callbacks[evt].ToArray();
            }

            foreach (var item in list)
            {
                item.Call(data);
            }
        }

        public void Emit(TEventName evt, IEncoder encoder, byte[] data) {
            EventCallback[] list;
            lock(m_locker) {
                if( ! m_callbacks.ContainsKey(evt)) return;
				list = m_callbacks[evt].ToArray();
            }

            foreach (var item in list)
            {
                item.Call(encoder, data);
            }
        }

        public void Clear() {
            lock(m_locker) {
                foreach (var item in m_callbacks)
                {
                    item.Value.Clear();
                }
                m_callbacks.Clear();
            }
        }
    }
}