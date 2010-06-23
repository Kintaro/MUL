using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	The value in the Type field is Isochronous Timestamp Packet for an ITP. 
	/// 	ITPs are used to deliver timestamps from the host to all active devices. 
	/// 	ITPs carry no addressing or routing information and are multicast by hubs 
	/// 	to all of their downstream ports with links in the U0 state. A device shall 
	/// 	not respond to an ITP. ITPs are used to provide host timing information to devices 
	/// 	for synchronization. Note that any device or hub may receive an ITP. The host shall 
	/// 	transmit an ITP on a root port link if and only if the link is already in U0. Only 
	/// 	the host shall initiate an ITP transmission. The host shall not bring a root port 
	/// 	link to U0 for the purpose of transmitting an ITP. The host shall transmit an ITP 
	/// 	in every bus interval within tTimestampWindow from a bus interval boundary if the 
	/// 	root port link is in U0. The host shall begin transmitting ITPs within 
	/// 	IsochronousTimestampStart from when the host root port’s link enters U0 from the polling 
	/// 	state. An ITP may be transmitted in between packets in a burst. If a device receives an 
	/// 	ITP with the delayed flag (DL) set in the link control word, the timestamp value may be 
	/// 	significantly inaccurate and may be ignored by the device.
	/// </summary>
	public class IsochronousTimestampPacket : AbstractPacket
	{
		/// <summary>
		/// 	The current 1/8 of a millisecond counter. The count 
		/// 	value rolls over to zero when the value reaches 0x3FFF 
		/// 	and continues to increment.
		/// </summary>
		private uint busIntervalCounter = 0;
		/// <summary>
		/// 	The time delta from the start of the current ITP packet 
		/// 	to the previous bus interval boundary. This value is a 
		/// 	number of tIsochTimestampGranularity units. The value used 
		/// 	shall specify the delta that comes closest to the previous 
		/// 	bus interval boundary without going before the boundary.
		/// 
		/// 	Note: If a packet starts exactly on a bus interval boundary, 
		/// 	the delta time is set to 0.
		/// </summary>
		public uint Delta = 0;
		/// <summary>
		/// 	This field specifies the address of the device that controls 
		/// 	the bus interval adjustment mechanism. Upon reset, power-up, 
		/// 	or if the device is disconnected, the host shall set this field to zero.
		/// </summary>
		public uint BusIntervalAdjustmentControl = 0;

		public IsochronousTimestampPacket () : base(PacketType.IsochronousTimestampPacket)
		{	
		}

		/// <summary>
		/// 	The current 1/8 of a millisecond counter. The count 
		/// 	value rolls over to zero when the value reaches 0x3FFF 
		/// 	and continues to increment.
		/// </summary>
		public uint BusIntervalCounter {
			get { return this.busIntervalCounter; }
			set { this.busIntervalCounter = value % 0x4000u; }
		}

		/// <summary>
		/// 	The isochronous timestamp field is used to identify the current 
		/// 	time value from the perspective of the host transmitting the ITP.
		/// </summary>
		public uint IsochronousTimestamp {
			get { return (this.Delta << 14) | (this.BusIntervalCounter); }
			set {
				this.BusIntervalCounter = value & 0x3FFFu;
				this.Delta = value >> 14;
			}
		}

		public override uint[] PacketData {

			get { return new uint[] { this.Type.Data | (this.IsochronousTimestamp << 5), this.BusIntervalAdjustmentControl, 0, this.LinkControlWord.Data }; }
		}
		
		public override string DetailedString {
			get {
				string result = base.DetailedString + "\n";
				result += "Bus Interval Counter: 0x" + this.BusIntervalCounter.ToString ("X") + "\n";
				result += "Delta: 0x" + this.Delta.ToString ("X");
				
				return result;
			}
		}
	}
}

