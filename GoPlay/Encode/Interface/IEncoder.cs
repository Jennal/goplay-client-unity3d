using GoPlay.Package;

namespace GoPlay.Encode.Interface
{
    public interface IEncoder
    {
        EncodingType Encoding { get; }
         byte[] Encode<T>(T data);
         T Decode<T>(byte[] buffer);
    }
}