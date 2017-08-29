using System;
using System.IO;
using GoPlay.Helper;

namespace GoPlay.Package
{
	public class Header
	{
        private const int CONST_LENGTH = 7;
		private static IDHelper s_IDHelper = new IDHelper(byte.MaxValue);

		public PackageType Type;
		public EncodingType Encoding;
		public byte ID;
		public Status Status;
		public UInt16 ContentSize;
		public string Route;

		public Header()
		{
			ID = (byte)s_IDHelper.Next();
		}

		public Header(Stream st) {
			SetFromStream(st);
		}

		public void SetFromStream(Stream st) {
			var br = new BigEndianReader(st);
			Type = (PackageType)br.ReadByte();
			Encoding = (EncodingType)br.ReadByte();
			ID = br.ReadByte();
			Status = (Status)br.ReadByte();
			ContentSize = br.ReadUInt16();

			var routeSize = br.ReadByte();
			var routeBytes = br.ReadBytes(routeSize);
			Route = System.Text.Encoding.UTF8.GetString(routeBytes);
		}

		public byte[] GetBytes() {
			using(var ms = new MemoryStream()) {
				using(var bw = new BigEndianWriter(ms)) {
					bw.Write((byte)Type);
					bw.Write((byte)Encoding);
					bw.Write(ID);
					bw.Write((byte)Status);
					bw.Write(ContentSize);

					var routeSize = Route.Length;
					var routeBytes = System.Text.Encoding.UTF8.GetBytes(Route);

					bw.Write((byte)routeSize);
					bw.Write(routeBytes);

					return ms.ToArray();
				}
			}
		}

        public static Header TrySetFromStream(Stream st)
        {
            var lastPos = st.Position;
            if (st.Length - st.Position < CONST_LENGTH) return null;

            var br = new BigEndianReader(st);
            var packageType = (PackageType)br.ReadByte();
            var encoding = (EncodingType)br.ReadByte();
            var id = br.ReadByte();
            var status = (Status)br.ReadByte();
            var contentSize = br.ReadUInt16();
            var routeSize = br.ReadByte();

            if (st.Length - st.Position < routeSize)
            {
                st.Position = lastPos;
                return null;
            }
            var routeBytes = br.ReadBytes(routeSize);
            var route = System.Text.Encoding.UTF8.GetString(routeBytes);

            return new Header
            {
                Type = packageType,
                Encoding = encoding,
                ID = id,
                Status = status,
                ContentSize = contentSize,
                Route = route
            };
        }

		public override string ToString() {
			return string.Format("Header{{ Type: {0}, Encoding: {1}, ID: {2}, Status: {3}, ContentSize: {4}, Route: \"{5}\" }}",
				Type,
				Encoding,
				ID,
				Status,
				ContentSize,
				Route ?? "");
		}
	}
}

