using System;
namespace MUL.Core
{
	public enum TransactionPacketSubtype
	{
		Reserved			= 0x00,
		ACK					= 0x01,
		NRDY				= 0x02,
		ERDY				= 0x03,
		STATUS				= 0x04,
		STALL				= 0x05,
		DevNotification		= 0x06,
		Ping				= 0x07,
		PingResponse		= 0x08
	}
}

