using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	The UNICODE string descriptor (shown in Table 9-22) is not 
	/// 	NULL-terminated. The string length is computed by subtracting 
	/// 	two from the value of the first byte of the descriptor.
	/// </summary>
	public class UnicodeStringDescriptor : AbstractDescriptor
	{
		/// <summary>
		/// 	UNICODE encoded string
		/// </summary>
		public string String { get; set; }
	}
}

