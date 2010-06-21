using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	SuperSpeed USB uses four basic packet types each with one or more subtypes. 
	/// </summary>
	public enum PacketType : byte
	{
		/// <summary>
		/// 	(LMP) only travel between a pair of links 
		/// 	(e.g., a pair of directly connected ports) and 
		/// 	is primarily used to manage that link.
		/// </summary>
		LinkManagementPacket		= 0x00,
		/// <summary>
		/// 	(TP) traverse all the links directly connecting the host to a device. 
		/// 	They are used to control the flow of data packets, configure devices, 
		/// 	and hubs, etc. Transaction Packets have no data payload.
		/// </summary>
		TransactionPacket			= 0x04,
		/// <summary>
		/// 	(DP) traverse all the links directly connecting the host to a device. 
		/// 	Data Packets have two parts: a Data Packet Header (DPH) and a 
		/// 	Data Packet Payload (DPP).
		/// </summary>
		DataPacket					= 0x08,
		/// <summary>
		/// 	(ITP) are multicast on all the active links from the host to one or more devices.
		/// </summary>
		IsochronousTimestampPacket	= 0x0C,
	}
}

