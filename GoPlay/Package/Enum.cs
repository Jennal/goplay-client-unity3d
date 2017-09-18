using System;

namespace GoPlay.Package
{
    public enum PackageType : byte
    {
        PKG_NOTIFY = 0x00,
        PKG_REQUEST = 0x01,
        PKG_RESPONSE = 0x02,
        PKG_PUSH = 0x03,
        PKG_HEARTBEAT = 0x04,
        PKG_HEARTBEAT_RESPONSE = 0x05,
        PKG_HAND_SHAKE = 0x06,
        PKG_HAND_SHAKE_RESPONSE = 0x07
    }

    public enum EncodingType : byte
    {
        ENCODING_NONE = 0x00,
        ENCODING_GOB = 0x01,
        ENCODING_JSON = 0x02,
        ENCODING_BSON = 0x03,
        ENCODING_PROTOBUF = 0x04
    }

}
