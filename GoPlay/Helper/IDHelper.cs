namespace GoPlay.Helper
{
    public class IDHelper
    {
        public int Max { get; private set; }
        private int m_current = 0;
        public IDHelper(int max)
        {
            this.Max = max;
        }

        public int Next() {
            var next = m_current;
            if(m_current == Max) {
                m_current = 0;
            } else {
                m_current++;
            }

            return next;
        }
    }
}