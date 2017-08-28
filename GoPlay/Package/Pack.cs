namespace GoPlay.Package
{
    public class Pack
    {
        public Header Header;
        public byte[] Data;

        public Pack(Header header, byte[] data)
        {
            Header = header;
            Data = data;
        }
    }
}