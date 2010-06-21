using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	The UNICODE string descriptor (shown in Table 9-22) is not 
	/// 	NULL-terminated. The string length is computed by subtracting 
	/// 	two from the value of the first byte of the descriptor.
	/// </summary>
	public class UnicodeStringDescriptor
	{
		/// <summary>
		/// 	Size of this descriptor in bytes
		/// </summary>
		public byte Length { get; set; }
		/// <summary>
		/// 	STRING Descriptor Type
		/// </summary>
		public DescriptorType DescriptorType { get; set; }
		/// <summary>
		/// 	UNICODE encoded string
		/// </summary>
		public string String { get; set; }
	}
}

