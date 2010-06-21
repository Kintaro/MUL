using System;
namespace MUL.Core.DeviceFramework
{
	public enum DescriptorType : byte
	{
		Device					= 0x01,
		Configuration			= 0x02,
		String					= 0x03,
		Interface				= 0x04,
		Endpoint				= 0x05,
		/* 0x06 and 0x07 are reserved */
		InterfacePower			= 0x08,
		OTG						= 0x09,
		Debug					= 0x0A,
		InterfaceAssociation 	= 0x0B,
		BOS						= 0x0F,
		DeviceCapability		= 0x10,
		SuperspeedUsbEndpointCompanion = 0x30,
	}
}

