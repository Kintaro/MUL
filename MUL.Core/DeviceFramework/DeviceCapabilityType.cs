using System;
namespace MUL.Core.DeviceFramework
{
	public enum DeviceCapabilityType
	{
		/// <summary>
		/// 	Defines the set of Wireless USB-specific device level capabilities
		/// </summary>
		WirelessUsb = 0x01,
		/// <summary>
		/// 	USB 2.0 Extension Descriptor
		/// </summary>
		Usb2Extension = 0x02,
		/// <summary>
		/// 	Defines the set of SuperSpeed USB specific device level capabilities
		/// </summary>
		SuperspeedUsb = 0x03,
		/// <summary>
		/// 	Defines the instance unique ID used to identify the instance 
		/// 	across all operating modes
		/// </summary>
		ContainerID = 0x04,
	}
}

