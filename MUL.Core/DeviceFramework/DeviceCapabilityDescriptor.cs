using System;
namespace MUL.Core.DeviceFramework
{
	public class DeviceCapabilityDescriptor
	{
		/// <summary>
		/// 	Size of this descriptor.
		/// </summary>
		public byte Length { get; set; }
		/// <summary>
		/// 	Descriptor type: DEVICE CAPABILITY Type.
		/// </summary>
		public DescriptorType DescriptorType { get; set; }
		/// <summary>
		/// 	Valid values are listed in Table 9-11.
		/// </summary>
		public DeviceCapabilityType DeviceCapavilityType { get; set; }
		/// <summary>
		/// 	Capability-specific format.
		/// </summary>
		public byte[] CapabilityDependentData { get; set; }
	}
}

