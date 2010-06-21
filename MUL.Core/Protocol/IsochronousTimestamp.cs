using System;
namespace MUL.Core.Protocol
{
	public class IsochronousTimestamp : IField
	{
		private ulong data = 0;

		/// <summary>
		/// 	The current 1/8 of a millisecond counter. 
		/// 	The count value rolls over to zero when 
		/// 	the value reaches 0x3FFF and continues to increment.
		/// </summary>
		public uint BusIntervalCounter {
			get { return (uint)(this.data & 0x3FFF); }
			set {
				this.data &= 0xFFFFFFFFFFFFC000ul;
				if (value > 0x000000003FFFu)
					value %= 0x000000003FFFu;
				this.data |= value & 0x000000003FFFu;
			}
		}

		/// <summary>
		/// 	The time delta from the start of the current 
		/// 	ITP packet to the previous bus interval boundary. 
		/// 	This value is a number of tIsochTimestampGranularity 
		/// 	units. The value used shall specify the delta that 
		/// 	comes closest to the previous bus interval boundary 
		/// 	without going before the boundary.
		/// 
		/// 	Note: If a packet starts exactly on a bus interval boundary, 
		/// 	the delta time is set to 0.
		/// </summary>
		public uint Delta {
			get { return (uint)((this.data & 0x000000007FFC000ul) >> 14); }
			set {
				this.data &= 0xFFFFFFFFF8003FFFul;
				this.data |= (value << 14) & 0x000000007FFC000ul;
			}
		}
		
		/// <summary>
		/// 	This field specifies the address of the device that controls 
		/// 	the bus interval adjustment mechanism. Upon reset, power-up, 
		/// 	or if the device is disconnected, the host shall set this field to zero.
		/// </summary>
		public byte BusIntervalAdjustmentControl {
			get { return (byte)((this.data >> 27) & 0x000000000000007Ful); }
			set {
				this.data &= 0xFFFFFFFC07FFFFFFul;
				this.data |= (ulong)(value << 27) & 0x000000000000007Ful;
			}
		}
		
		public int Width {
			get {
				return 91;
			}
		}
	}
}

