using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	The BOS descriptor defines a root descriptor that is 
	/// 	similar to the configuration descriptor, and is the 
	/// 	base descriptor for accessing a family of related descriptors. 
	/// 	A host can read a BOS descriptor and learn from the 
	/// 	TotalLength field the entire size of the device-level 
	/// 	descriptor set, or it can read in the entire BOS descriptor 
	/// 	set of device capabilities.
	/// </summary
	public class BinaryObjectDeviceStoreDescriptor
	{
		/// <summary>
		/// 	Size of descriptor
		/// </summary>
		public byte Number { get; set; }
		/// <summary>
		/// 	BOS Descriptor type
		/// </summary>
		public DescriptorType DescriptorType { get; set; }
		/// <summary>
		/// 	Length of this descriptor and all of its sub descriptors
		/// </summary>
		public ushort TotalLength { get; set; }
		/// <summary>
		/// 	The number of separate device capability descriptors in the BOS
		/// </summary>
		public byte NumberOfDeviceCapabilityDescriptors { get; set; }
	}
}

