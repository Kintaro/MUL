using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	The configuration descriptor describes information about 
	/// 	a specific device configuration. The descriptor contains a 
	/// 	bConfigurationValue field with a value that, when used as 
	/// 	a parameter to the SetConfiguration() request, causes the 
	/// 	device to assume the described configuration.
	/// 
	/// 	The descriptor describes the number of interfaces provided 
	/// 	by the configuration. Each interface may operate independently. 
	/// 	For example, a Video Class device might be configured with two 
	/// 	interfaces, each providing 64-MBps bi-directional channels that 
	/// 	have separate data sources or sinks on the host. 
	/// 	Another configuration might present the Video Class device as 
	/// 	a single interface, bonding the two channels into one 128-MBps 
	/// 	bi-directional channel.
	/// 
	/// 	When the host requests the configuration descriptor, all related 
	/// 	interface, endpoint, and endpoint companion descriptors are 
	/// 	returned (refer to Section 9.4.3).
	/// 
	/// 	A device has one or more configuration descriptors. 
	/// 	Each configuration has one or more interfaces and each interface 
	/// 	has zero or more endpoints. An endpoint is not shared among 
	/// 	interfaces within a single configuration unless the endpoint 
	/// 	is used by alternate settings of the same interface. 
	/// 	Endpoints may be shared among interfaces that are part of 
	/// 	different configurations without this restriction.
	/// 
	/// 	Once configured, devices may support limited adjustments to the 
	/// 	configuration. If a particular interface has alternate settings, 
	/// 	an alternate may be selected after configuration. 
	/// </summary>
	public class StandardConfigurationDescriptor
	{
		/// <summary>
		/// 	Size of this descriptor in bytes
		/// </summary>
		public byte Length { get; set; }
		/// <summary>
		/// 	CONFIGURATION Descriptor Type
		/// </summary>
		public byte DescriptorType { get; set; }
		/// <summary>
		/// 	Total length of data returned for this 
		/// 	configuration. Includes the combined length 
		/// 	of all descriptors (configuration, interface, 
		/// 	endpoint, and class- or vendor-specific) 
		/// 	returned for this configuration
		/// </summary>
		public ushort TotalLength { get; set; }
		/// <summary>
		/// 	Number of interfaces supported by this configuration
		/// </summary>
		public byte NumberOfInterfaces { get; set; }
		/// <summary>
		/// 	Value to use as an argument to the SetConfiguration() 
		/// 	request to select this configuration
		/// </summary>
		public byte ConfigurationValue { get; set; }
		/// <summary>
		/// 	Index of string descriptor describing this configuration
		/// </summary>
		public byte Configuration { get; set; }
		/// <summary>
		/// 	Configuration characteristics:
		/// 
		/// 	D7: Reserved (set to one)
		/// 	D6: Self-powered
		/// 	D5: Remote Wakeup
		/// 	D4..0: Reserved (reset to zero)
		/// 
		/// 	D7 is reserved and shall be set to one for historical reasons.
		/// 
		/// 	A device configuration that uses power from the bus and a local 
		/// 	source reports a non-zero value in bMaxPower to indicate the 
		/// 	amount of bus power required and sets D6. The actual power 
		/// 	source at runtime may be determined using the 
		/// 	GetStatus(DEVICE) request (refer to Section 9.4.5).
		/// 
		/// 	If a device configuration supports remote wakeup, D5 is set to one.
		/// </summary>
		public byte Attributes { get; set; }
		/// <summary>
		/// 	Maximum power consumption of the device from the bus in 
		/// 	this specific configuration when the device is
		/// 	fully operational. Expressed in 2-mA units when the device is 
		/// 	operating in high-speed mode and in 8-mA units when operating 
		/// 	in SuperSpeed mode. (i.e., 50 = 100 mA in high-speed mode and 
		/// 	50 = 400 mA in SuperSpeed mode).
		/// 
		/// 	Note: A device configuration reports whether the configuration 
		/// 	is bus-powered or self-powered. Device status reports whether 
		/// 	the device is currently self-powered. If a device is disconnected 
		/// 	from its external power source, it updates device status to 
		/// 	indicate that it is no longer self-powered.
		/// 	
		/// 	A device may not increase its power draw from the bus, when it 
		/// 	loses its external power source, beyond the amount reported by 
		/// 	its configuration.
		/// 
		/// 	If a device can continue to operate when disconnected from its 
		/// 	external power source, it continues to do so. If the device 
		/// 	cannot continue to operate, it shall return to the Powered state.
		/// </summary>
		public byte MaxPower { get; set; }
	}
}

