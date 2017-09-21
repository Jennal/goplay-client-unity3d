using GoPlay.Package;

namespace GoPlay.Encode.Interface
{
    public interface IEncoder
    {
         EncodingType Encoding { get; }
         bool IsProperType<T>();
         byte[] Encode<T>(T data);
         T Decode<T>(byte[] buffer);
    }
}