using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	All header packets have a 16-bit CRC field. 
	/// 	This field is the CRC calculated over the 
	/// 	preceding 12 bytes in the header packet. 
	/// 	Refer to Section 7.2.1.1.2 for the polynomial 
	/// 	used to calculate this value.
	/// </summary>
	public class Crc16Field : AbstractField
	{
		public override int Width {
			get {
				return 16;
			}
		}
	}
}

