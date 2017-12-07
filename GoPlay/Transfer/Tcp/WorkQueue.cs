using System;
using System.Collections.Generic;
using System.Threading;

namespace GoPlay.Transfer.Tcp
{
    public class WorkQueue
    {
        private object m_locker = new object();
        private Queue<KeyValuePair<Action, Action<Exception>>> m_queue = new Queue<KeyValuePair<Action, Action<Exception>>>();
        private Thread m_thread;

        public WorkQueue()
        {
            Start();
        }
        
        public void Enqueue(Action action, Action<Exception> onError)
        {
            lock (m_locker)
            {
                m_queue.Enqueue(new KeyValuePair<Action, Action<Exception>>(action, onError));
            }
        }

        public void Start()
        {
            m_thread = new Thread(() =>
            {
                while (true)
                {
                    if(m_queue.Count <= 0) continue;

                    KeyValuePair<Action, Action<Exception>> pair;
                    lock (m_locker)
                    {
                        if (m_queue.Count <= 0) continue;
                        pair = m_queue.Dequeue();
                    }

                    try
                    {
                        pair.Key();
                    }
                    catch (Exception err)
                    {
                        pair.Value(err);
                    }
                }
            });
            m_thread.Start();
        }

        public void Stop()
        {
            if (m_thread == null) return;

            m_thread.Abort();
            m_thread.Join();
            m_thread = null;
        }
    }
}