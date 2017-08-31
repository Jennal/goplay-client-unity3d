using System;
using System.Threading;

namespace GoPlay.Helper
{
    public static class DelayCall
    {
        public static void Do(int delayMilliSecond, Action action)
        {
            var timer = new Timer(o =>
            {
                action();
            }, null, delayMilliSecond, Timeout.Infinite);
        }
    }
}
