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

		public override int Width {
			get { return 16; }
		}

		public override uint Data {
			get { return HeaderSequenceNumber.Data | HubDepth.Data | Delayed.Data | Deferred.Data | Crc5.Data; }
			set { this.data = value; }
		}
	}
}

