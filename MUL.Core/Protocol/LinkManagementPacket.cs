using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	These packets are used to manage a single link. They carry no 
	/// 	addressing information and as such are not routable. They may 
	/// 	be generated as the result of hub port commands. For example, 
	/// 	a hub port command is used to set the U2 inactivity timeout. 
	/// 	In addition, they are used to exchange port capability information 
	/// 	and testing purposes.
	/// </summary>
	public abstract class LinkManagementPacket : AbstractPacket
	{
		/// <summary>
		/// 	These 4 bits identify the Link Packet Subtype.
		/// </summary>
		public enum LinkManagementPacketSubtype : uint
		{
			SetLinkFunction = 0x01,
			U2InactivityTimeout = 0x02,
			VendorDeviceTest = 0x03,
			PortCapability = 0x04,
			PortConfiguration = 0x05,
			PortConfigurationResponse = 0x06
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected LinkManagementPacketSubtype Subtype;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="subType">
		/// A <see cref="LinkManagementPacketSubtype"/>
		/// </param>
		protected LinkManagementPacket (LinkManagementPacketSubtype subType) : base (PacketType.LinkManagementPacket)
		{
			this.Subtype = subType;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override uint[] PacketData {
			get { return new uint[] { this.Type.Data | ((uint)this.Subtype << 5) | this.SubtypeSpecificField << 9, this.InternalData[0], this.InternalData[1], this.LinkControlWord.Data | this.Crc16.Data }; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected virtual uint[] InternalData {
			get { return new uint[] { 0, 0 }; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected abstract uint SubtypeSpecificField { get; }
	}
}

