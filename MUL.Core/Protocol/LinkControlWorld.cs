using System;
namespace MUL.Core.Protocol
{
	public class LinkControlWorld : AbstractField
	{
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
				this.data = data | Crc5.Data;
				return base.Data;
			}
			set 
			{
				this.data = value;
				this.HeaderSequenceNumber.Data = value >> this.HeaderSequenceNumber.Offset;
				this.HubDepth.Data = value >> this.HubDepth.Offset;
				this.Delayed.Data = value >> this.Delayed.Offset;
				this.Deferred.Data = value >> this.Deferred.Offset;
				uint crc = Util.Crc5.Perform (this.data & 0x7FFu, 11);
				this.Crc5.Data = crc;
			}
		}
	}
}

