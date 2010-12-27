using System;
using System.Net;

namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	The 2-byte Link Control Word is used for both link level 
	/// 	and end-to-end flow control.
	/// 
	///		The Link Control Word shall contain a 3-bit Header Sequence Number, 
	///		3-bit Reserved, a 3-bit Hub Depth Index, a Delayed bit (DL), 
	///		a Deferred bit (DF), and a 5-bit CRC-5.
	/// </summary>
	public class LinkControlWorld : AbstractField
	{
		/// <summary>
		/// 	The valid values in this field are 0 through 7.
		/// </summary>
		public class HeaderSequenceNumberField : AbstractField
		{
			public HeaderSequenceNumberField ()
			{
				this.Offset = 0;
			}

			public override int Width {
				get { return 3; }
			}
		}
		
		/// <summary>
		/// 	This field is only valid when the Deferred bit is set and 
		/// 	identifies to the host the hierarchical on the USB that the 
		/// 	hub is located at in the deferred TP or DPH returned to the host. 
		/// 	This informs the host that the port on which the packet was 
		/// 	supposed to be forwarded on is currently in a low power state 
		/// 	(either U1 or U2).
		///
		///		The only valid values in this field are 0 through 4.
		/// </summary>
		public class HubDepthField : AbstractField
		{
			public HubDepthField ()
			{
				this.Offset = 6;
			}

			public override int Width {
				get { return 3; }
			}
		}
		
		/// <summary>
		/// 	This bit shall be set if a Header Packet is resent or the 
		/// 	transmission of a Header Packet is delayed. Chapter 7 and 
		/// 	Chapter 10 provide more details on when this bit shall be set.
		///
		///		This bit shall not be reset by any subsequent hub that this packet traverses.
		/// </summary>
		public class DelayedField : AbstractField
		{
			public DelayedField ()
			{
				this.Offset = 9;
			}

			public override int Width {
				get { return 1; }
			}
		}
		
		/// <summary>
		/// 	This bit may only be set by a hub. This bit shall be set when 
		/// 	the downstream port on which the packet needs to be sent is in 
		/// 	a power managed state.
		///
		///		This bit shall not be reset by any subsequent hub that this 
		///		packet traverses.
		/// </summary>
		public class DeferredField : AbstractField
		{
			public DeferredField ()
			{
				this.Offset = 10;
			}

			public override int Width {
				get { return 1; }
			}
		}

		public HeaderSequenceNumberField HeaderSequenceNumber = new HeaderSequenceNumberField ();
		public HubDepthField HubDepth = new HubDepthField ();
		public DelayedField Delayed = new DelayedField ();
		public DeferredField Deferred = new DeferredField ();
		public Crc5Field Crc5 = new Crc5Field ();
		
		public LinkControlWorld ()
		{
			Crc5.Offset = 11;
		}
		
		public LinkControlWorld (uint headerSequenceNumber, uint hubDepth, bool delayed, bool deferred)
		{
			Crc5.Offset = 11;
			this.HeaderSequenceNumber.Data = headerSequenceNumber;
			this.HubDepth.Data = hubDepth;
			this.Delayed.Data = delayed ? 1u : 0u;
			this.Deferred.Data = deferred ? 1u : 0u;
			uint data = HeaderSequenceNumber.Data | HubDepth.Data | Delayed.Data | Deferred.Data;
			uint crc = Util.Crc5.Perform (data & 0x7FFu, 11);
			this.Crc5.Data = crc;
		}

		public override int Width {
			get { return 16; }
		}

		public override uint Data {
			get 
			{
				uint data = HeaderSequenceNumber.Data | HubDepth.Data | Delayed.Data | Deferred.Data;
				uint crc = Util.Crc5.Perform (data & 0x7FFu, 11);
				this.Crc5.Data = crc;
				this.RawData = data | Crc5.Data;
				return base.Data;
			}
			set 
			{
				this.RawData = value;
				this.HeaderSequenceNumber.Data = value >> this.HeaderSequenceNumber.Offset;
				this.HubDepth.Data = value >> this.HubDepth.Offset;
				this.Delayed.Data = value >> this.Delayed.Offset;
				this.Deferred.Data = value >> this.Deferred.Offset;
				uint crc = Util.Crc5.Perform (this.RawData & 0x7FFu, 11);
				this.Crc5.Data = crc;
			}
		}
		
		public override string ToString ()
		{
			string result = string.Empty;
			result += "LinkControlWord:\n";
			result += "  + Header Sequence Number: " + this.HeaderSequenceNumber + "\n";
			result += "  + Hub Depth: " + this.HubDepth + "\n";
			result += "  + Delayed: " + (this.Delayed.RawData != 0 ? true : false) + "\n";
			result += "  + Deferred: " + (this.Deferred.RawData != 0 ? true : false) + "\n";
			result += "  + Crc5 Checksum: " + this.Crc5;
			
			return result;
		}
	}
}

