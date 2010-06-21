using System;
namespace MUL.Core
{
	/// <summary>
	/// 	The value in the LMP Subtype field further 
	/// 	identifies the content of the LMP.
	/// </summary>
	public class LinkPacketSubtypeField : IField
	{
		private ushort crc16 = 0;
		private LinkPacketSubtype subtype;
	
		/// <summary>
		/// 	This field is the CRC calculated over the 
		/// 	preceding 12 bytes. Refer to Section 7.2.1.1.2 
		/// 	for the polynomial used to calculate this value.
		/// </summary>
		public ushort Crc16 {
			get {
				return this.crc16;
			}
			set {
				crc16 = value;
			}
		}

		/// <summary>
		/// 	These 4 bits identify the Link Packet Subtype.
		/// </summary>
		public LinkPacketSubtype Subtype {
			get {
				return this.subtype;
			}
			set {
				subtype = value;
			}
		}
		
		public int Width {
			get {
				return 20;
			}
		}
	}
}

