using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	The value in the LMP Subtype field further identifies the content of the LMP.
	/// </summary>
	public enum LinkPacketSubtype : byte
	{
		Reserved 					= 0x00,
		SetLinkFunction				= 0x01,
		U2InactivityTimeout			= 0x02,
		VendorDeviceTest			= 0x03,
		PortCapability				= 0x04,
		PortConfiguration			= 0x05,
		PortConfigurationResponse	= 0x06,
	}
}

