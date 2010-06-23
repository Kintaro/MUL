using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	This TP can only be sent by a device for a non-isochronous endpoint. 
	/// 	It is used to inform the host that an endpoint is ready to send or 
	/// 	receive data packets. 
	/// </summary>
	public class EndpointReadyPacket : TransactionPacket
	{
		/// <summary>
		/// 	For an OUT endpoint, refer to Table 8-12 for the description of this field.
		/// 
		/// 	For an IN endpoint this field is set by the endpoint to the number of packets 
		/// 	it can transmit when the host resumes transactions to it. This field shall not 
		/// 	have a value greater than the maximum burst size supported by the endpoint as 
		/// 	indicated by the value in the Burst Size field in the Endpoint Companion Descriptor. 
		/// 	Note that the value reported in this field may be treated by the host as informative only.
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
		/// 	Endpoint Number (Ept Num). This field determines an 
		/// 	endpoint within the device that is the source or r
		/// 	ecipient of this TP. Refer to Section 8.8.
		/// </summary>
		public EndpointNumberField EndpointNumber = new EndpointNumberField ();
		/// <summary>
		/// 	This field defines the direction of an endpoint within 
		/// 	the device that is the source or recipient of this TP. 
		/// 	Refer to Section 8.8.
		/// </summary>
		public DirectionField Direction = new DirectionField ();
		/// <summary>
		/// 	If this ACK TP is targeted at a Bulk endpoint, this field 
		/// 	contains a Stream ID value between 1 and 65535. The Stream ID 
		/// 	value of 0 is reserved for Stream pipes. The usage of this 
		/// 	field is class dependent. This field shall be set to zero if 
		/// 	the Bulk endpoint does not support Streams.
		/// </summary>
		public StreamIdField StreamId = new StreamIdField ();
		/// <summary>
		/// 	For an OUT endpoint, refer to Table 8-12 for the description of this field.
		/// 
		/// 	For an IN endpoint this field is set by the endpoint to the number of packets 
		/// 	it can transmit when the host resumes transactions to it. This field shall not 
		/// 	have a value greater than the maximum burst size supported by the endpoint as 
		/// 	indicated by the value in the Burst Size field in the Endpoint Companion Descriptor. 
		/// 	Note that the value reported in this field may be treated by the host as informative only.
		/// </summary>
		public NumberOfPacketsField NumberOfPackets = new NumberOfPacketsField ();

		public EndpointReadyPacket () : base(TransactionPacketSubtype.EndpointReady)
		{
		}

		public EndpointReadyPacket (uint deviceAddress) : base(TransactionPacketSubtype.EndpointReady, deviceAddress)
		{
		}

		protected override uint[] InternalData {
			get { return new uint[] { this.Direction.Data | this.EndpointNumber.Data | this.NumberOfPackets.Data, this.StreamId.Data }; }
		}

		public override string DetailedString {
			get {
				string result = base.DetailedString + "\n";
				result += "Direction: " + this.Direction.Direction.ToString () + "\n";
				result += "Endpoint Number: " + this.EndpointNumber + "\n";
				result += "Number of Packets: " + this.NumberOfPackets + "\n";
				result += "Stream ID: " + this.StreamId + "\n";
				
				return result;
			}
		}
	}
}

