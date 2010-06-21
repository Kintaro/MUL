using System;
namespace MUL.Core.DeviceFramework
{
	public class DeviceCapabilityDescriptor : AbstractDescriptor
	{
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

