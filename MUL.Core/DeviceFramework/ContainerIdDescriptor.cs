using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	This descriptor may be used by a host in order to 
	/// 	identify a unique device instance across all operating 
	/// 	modes. If a device can also connect to a host through 
	/// 	other technologies, the same Container ID value contained 
	/// 	in this descriptor should also be provided over those other 
	/// 	technologies in a technology specific manner.
	/// </summary>
	public class ContainerIdDescriptor
	{
		/// <summary>
		/// 	Size of descriptor
		/// </summary>
		public byte Length { get; set; }
		/// <summary>
		/// 	DEVICE CAPABILITY Descriptor type
		/// </summary>
		public DescriptorType DescriptorType { get; set; }
		/// <summary>
		/// 	Capability type: CONTAINER_ID
		/// </summary>
		public byte DeviceCapabilityDescriptor { get; set; }
		/// <summary>
		/// 	This field is reserved and shall be set to zero.
		/// </summary>
		public byte Reserved { get; set; }
		/// <summary>
		/// 	This is a 128-bit number that is unique to a device 
		/// 	instance that is used to uniquely identify the device 
		/// 	instance across all modes of operation. This same value 
		/// 	may be provided over other technologies as well to allow 
		/// 	the host to identify the device independent of means
		/// 	of connectivity.
		/// </summary>
		public Guid ContainerID { get; set; }
	}
}

