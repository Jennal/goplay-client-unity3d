using System;

namespace GoPlay.Package
{
	public enum Status : byte {
		STAT_OK                = 0x00,
		STAT_ERR               = 0x90,
		STAT_ERR_WRONG_PARAMS  = 0x91,
		STAT_ERR_DECODE_FAILED = 0x92,
		STAT_ERR_TIMEOUT       = 0x93,
		STAT_ERR_EMPTY_RESULT  = 0x94
	}

	public enum PackageType : byte {
		PKG_NOTIFY             = 0x00,
		PKG_REQUEST            = 0x01,
		PKG_RESPONSE           = 0x02,
		PKG_PUSH               = 0x03,
		PKG_HEARTBEAT          = 0x04,
		PKG_HEARTBEAT_RESPONSE = 0x05
	}

	public enum EncodingType : byte {
		ENCODING_NONE     = 0x00,
		ENCODING_GOB      = 0x01,
		ENCODING_JSON     = 0x02,
		ENCODING_BSON     = 0x03,
		ENCODING_PROTOBUF = 0x04
	}

}
