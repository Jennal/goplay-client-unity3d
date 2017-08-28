using System.IO;

namespace GoPlay.Helper
{
    public class BigEndianWriter : BinaryWriter
    {
        public BigEndianWriter(Stream output) : base(output)
        {
        }

        public override void Write(ushort value) {
            this.Write((byte)(value >> 8));
            this.Write((byte)(value & 0x00FF));
        }
    }
}