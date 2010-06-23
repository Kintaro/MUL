using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	This TP is used for two purposes:
	/// 		+	For IN endpoints, this TP is sent by the host to 
	/// 		    request data from a device as well as to acknowledge 
	/// 		    the previously received data packet.
	/// 		+	For OUT endpoints, this TP is sent by a device to 
	/// 		    acknowledge receipt of the previous data packet sent 
	/// 		    by the host, as well as to inform the host of the number 
	/// 		    of data packet buffers it has available after receipt of 
	/// 		    this packet.
	/// </summary>
	public class AcknowledgementPacket : TransactionPacket
	{
		/// <summary>
		/// 	This field is used to indicate the number of Data Packet buffers 
		/// 	that the receiver can accept. The value in this field shall be 
		/// 	less than or equal to the maximum burst size supported by the 
		/// 	endpoint as determined by the value in the Burst Size field in 
		/// 	the Endpoint Companion Descriptor (refer to Section 9.6.7).
		/// </summary>
		public class NumberOfPacketsField : AbstractField
		{
			public NumberOfPacketsField ()
			{
				this.Offset = 16;
			}

			public override int Width {
				get { return 5; }
			}
		}

		/// <summary>
		/// 	This field is used to identify the sequence number of the 
		/// 	next expected data packet.
		/// </summary>
		public class SequenceNumberField : AbstractField
		{
			public SequenceNumberField ()
			{
				this.Offset = 21;
			}

			public override int Width {
				get { return 5; }
			}
		}
		
		/// <summary>
		/// 	This field is used to signal that the host or a device did not 
		/// 	receive a data packet or received a corrupted data packet and 
		/// 	requests the transmitter to resend one or more data packets 
		/// 	starting at the specified sequence number.
		/// </summary>
		public class RetryDataPacketField : AbstractField
		{
			public RetryDataPacketField ()
			{
				this.Offset = 6;
			}

			public override int Width {
				get { return 1; }
			}
		}
		
		/// <summary>
		/// 	This field is only valid when the ACK TP is sent from the host to 
		/// 	a device. This bit shall be set if the host was unable to accept 
		/// 	a valid data packet due to internal host issues. When the host 
		/// 	sets this field, it must also set the Retry Data Packet field 
		/// 	for a non-isochronous transfer.
		/// </summary>
		public class HostErrorField : AbstractField
		{
			public HostErrorField ()
			{
				this.Offset = 15;
			}

			public override int Width {
				get { return 1; }
			}
		}
		
		/// <summary>
		/// 	This field can only be set by the Host. If the field is set the 
		/// 	host has another packet available for the endpoint identified by 
		/// 	the Endpoint Number and Direction field.
		/// 
		/// 	If no endpoints on this device have packets pending, then the 
		/// 	device can use this information to aggressively power manage its 
		/// 	upstream link, e.g., set the link to a lower power U1 or U2 state.
		/// </summary>
		public class PacketsPendingField : AbstractField
		{
			public PacketsPendingField ()
			{
				this.Offset = 27;
			}
			
			public override int Width {
				get { return 1; }
			}
		}

		
		/// <summary>
		/// 	If this ACK TP is targeted at a Bulk endpoint, this field 
		/// 	contains a Stream ID value between 1 and 65535. The Stream ID 
		/// 	value of 0 is reserved for Stream pipes. The usage of this 
		/// 	field is class dependent. This field shall be set to zero if 
		/// 	the Bulk endpoint does not support Streams.
		/// </summary>
		public StreamIdField StreamId = new StreamIdField ();
		/// <summary>
		/// 	Endpoint Number (Ept Num). This field determines an 
		/// 	endpoint within the device that is the source or r
		/// 	ecipient of this TP. Refer to Section 8.8.
		/// </summary>
		public EndpointNumberField EndpointNumber = new EndpointNumberField ();
		/// <summary>
		/// 	This field is used to indicate the number of Data Packet buffers 
		/// 	that the receiver can accept. The value in this field shall be 
		/// 	less than or equal to the maximum burst size supported by the 
		/// 	endpoint as determined by the value in the Burst Size field in 
		/// 	the Endpoint Companion Descriptor (refer to Section 9.6.7).
		/// </summary>
		public NumberOfPacketsField NumberOfPackets = new NumberOfPacketsField ();
		/// <summary>
		/// 	This field is used to identify the sequence number of the 
		/// 	next expected data packet.
		/// </summary>
		public SequenceNumberField SequenceNumber = new SequenceNumberField ();
		/// <summary>
		/// 	This field defines the direction of an endpoint within 
		/// 	the device that is the source or recipient of this TP. 
		/// 	Refer to Section 8.8.
		/// </summary>
		public DirectionField Direction = new DirectionField ();
		/// <summary>
		/// 	This field is used to signal that the host or a device did not 
		/// 	receive a data packet or received a corrupted data packet and 
		/// 	requests the transmitter to resend one or more data packets 
		/// 	starting at the specified sequence number.
		/// </summary>
		public RetryDataPacketField RetryDataPacket = new RetryDataPacketField ();
		/// <summary>
		/// 	This field is only valid when the ACK TP is sent from the host to 
		/// 	a device. This bit shall be set if the host was unable to accept 
		/// 	a valid data packet due to internal host issues. When the host 
		/// 	sets this field, it must also set the Retry Data Packet field 
		/// 	for a non-isochronous transfer.
		/// </summary>
		public HostErrorField HostError = new HostErrorField ();
		/// <summary>
		/// 	This field can only be set by the Host. If the field is set the 
		/// 	host has another packet available for the endpoint identified by 
		/// 	the Endpoint Number and Direction field.
		/// 
		/// 	If no endpoints on this device have packets pending, then the 
		/// 	device can use this information to aggressively power manage its 
		/// 	upstream link, e.g., set the link to a lower power U1 or U2 state.
		/// </summary>
		public PacketsPendingField PacketsPending = new PacketsPendingField ();

		public AcknowledgementPacket () : base(TransactionPacketSubtype.Acknowledgement)
		{
		}
		
		protected override uint[] InternalData {
			get {
				return new uint[]
				{
					(uint)this.Subtype | this.RetryDataPacket.Data | this.Direction.Data | this.EndpointNumber.Data | this.HostError.Data | this.NumberOfPackets.Data | this.SequenceNumber.Data,
					this.StreamId.Data | this.PacketsPending.Data
				};
			}
		}
	}
}

