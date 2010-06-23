using System;
namespace MUL.Core.Protocol
{
	public abstract class LinkManagementPacket : AbstractPacket
	{
		public enum LinkManagementPacketSubtype : uint
		{
			SetLinkFunction = 0x01,
			U2InactivityTimeout = 0x02,
			VendorDeviceTest = 0x03,
			PortCapability = 0x04,
			PortConfiguration = 0x05,
			PortConfigurationResponse = 0x06
		}

		protected LinkManagementPacketSubtype Subtype;
		
		protected LinkManagementPacket (LinkManagementPacketSubtype subType)
		{
			this.Subtype = subType;
		}

		public override uint[] PacketData {
			get { return new uint[] { this.Type.Data | ((uint)this.Subtype << 5) | this.SubtypeSpecificField << 9, this.InternalData[0], this.InternalData[1], this.LinkControlWord.Data }; }
		}

		protected virtual uint[] InternalData {
			get { return new uint[] { 0, 0 }; }
		}

		protected abstract uint SubtypeSpecificField { get; }
	}
}

