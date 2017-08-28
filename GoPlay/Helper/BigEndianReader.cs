using System.IO;

namespace GoPlay.Helper
{
    public class BigEndianReader : BinaryReader
    {
        public BigEndianReader(Stream input) : base(input)
        {
        }

        public override ushort ReadUInt16() {
            var h = base.ReadByte();
            var l = base.ReadByte();

            // Debug.LogFormat("h: {0:X}, l: {1:X}", h, l);
            var result = (ushort)((ushort)h << 8 | l);
            // Debug.LogFormat("result: {0:X}, {1}", result, result);
            return result;
        }
    }
}