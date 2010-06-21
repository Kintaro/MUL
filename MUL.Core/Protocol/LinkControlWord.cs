using System;
namespace MUL.Core
{
	/// <summary>
	/// 	The 2-byte Link Control Word is  used for both link level 
	/// 	and end-to-end flow control. The Link Control Word shall 
	/// 	contain a 3-bit Header Sequence Number, 3-bit Reserved, 
	/// 	a 3-bit Hub Depth Index, a Delayed bit (DL), a Deferred bit (DF), 
	/// 	and a 5-bit CRC-5.
	/// </summary>
	public class LinkControlWord : IField
	{
		/// <summary>
		/// 	Holds the 2-byte Link Control Word
		/// </summary>
		private ushort data = 0;

		/// <summary>
		/// 	Header Sequence Number. The valid values in this field are 0 through 7.
		/// </summary>
		public byte HeaderSequenceNumber {
			get { return (byte)(data & 0x0007); }
			set {
				data &= (ushort)0xFFF8u;
				data |= (ushort)(value & 0x0007u);
			}
		}

		/// <summary>
		/// 	This field is only valid when the Deferred bit is set and 
		/// 	identifies to the host the hierarchical on the USB that the 
		/// 	hub is located at in the deferred TP or DPH returned to the host. 
		/// 	This informs the host that the port on which the packet was 
		/// 	supposed to be forwarded on is currently in a low power state 
		/// 	(either U1 or U2). The only valid values in this field are 0 through 4.
		/// </summary>
		public byte HubDepth {
			get { return (byte)(data & 0x01C0); }
			set {
				data &= (ushort)0xFE3Fu;
				data |= (ushort)((value << 6) & 0x01C0u);
			}
		}

		/// <summary>
		/// 	This bit shall be set if a Header Packet is resent or the 
		/// 	transmission of a Header Packet is delayed. Chapter 7 and 
		/// 	Chapter 10 provide more details on when this bit shall be set.
		/// 	This bit shall not be reset by any subsequent hub that 
		/// 	this packet traverses.
		/// </summary>
		public bool Delayed {
			get { return (data & 0x0200) == 0x0200; }
			set {
				data &= (ushort)0xFDFF;
				data |= (ushort)(((value ? 1 : 0) << 9) & 0x0200);
			}
		}

		/// <summary>
		/// 	This bit may only be set by a hub. This bit shall be set 
		/// 	when the downstream port on which the packet needs to be 
		/// 	sent is in a power managed state. This bit shall not be 
		/// 	reset by any subsequent hub that this packet traverses.
		/// </summary>
		public bool Deferred {
			get { return (data & 0x0400) == 0x0400; }
			set {
				data &= (ushort)0xFBFF;
				data |= (ushort)(((value ? 1 : 0) << 10) & 0x0400);
			}
		}

		/// <summary>
		/// 	This field is the CRC used to verify the correctness of 
		/// 	the preceding 11 bits in this word. Refer to Section 7.2.1.1.3 
		/// 	for the polynomial used to calculate this value.
		/// </summary>
		public byte Crc5 {
			get { return (byte)(data & 0xF800); }
			set {
				data &= (ushort)0x07FF;
				data |= (ushort)((value << 11) & 0xF800);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ushort Value {
			get { return this.data; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public int Width 
		{
			get { return 16; }
		}
	}
}

