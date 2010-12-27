using System;
namespace MUL.Core.DeviceFramework
{
	public abstract class AbstractDescriptor
	{
		/// <summary>
		/// 	Size of this descriptor in bytes
		/// </summary>
		public byte Length { get; set; }
		/// <summary>
		/// 	Descriptor Type
		/// </summary>
		public DescriptorType DescriptorType { get; set; }
	}
}

