using System;
using System.Collections.Generic;
using GoPlay.Package;

namespace GoPlay.Transfer
{
	public interface ITransfer
	{
		event Action<ITransfer> OnConnected;
		event Action<ITransfer> OnDisconnected;
		event Action<Exception> OnError;

		bool Connceted{ get; }
		bool CanRead { get; }

		void Connect(string host, int port);
		void Disconnect();

        void ReadAsync(Action<byte[]> callback);
        void WriteAsync(byte[] buffer);
	}
}
