using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	Packets that have the Type field set to Link Management Packet 
	/// 	are referred to as LMPs. These packets are used to manage a 
	/// 	single link. They carry no addressing information and as such 
	/// 	are not routable. They may be generated as the result of hub 
	/// 	port commands. For example, a hub port command is used to set 
	/// 	the U2 inactivity timeout. In addition, they are used to 
	/// 	exchange port capability information and testing purposes.
	/// </summary>
	public abstract class LinkManagementPacket : AbstractPacket
	{
		/// <summary>
		/// 
		/// </summary>
		protected LinkPacketSubtypeField subtypeField;
		
		/// <summary>
		/// 
		/// </summary>
		public LinkPacketSubtypeField SubtypeField
		{
			get { return this.subtypeField; }
			set { this.subtypeField = value; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public uint FirstPacket
		{
			get
			{
				return ((uint)(this.LinkControlWord.Value << 16) | (uint)this.SubtypeField.Crc16);
			}
		}
	}
}

