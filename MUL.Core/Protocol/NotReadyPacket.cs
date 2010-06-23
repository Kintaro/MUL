using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	This TP can only be sent by a device for a non-isochronous 
	/// 	endpoint. An OUT endpoint sends this TP to the host if it 
	/// 	has no packet buffer space available to accept the DP sent 
	/// 	by the host. An IN endpoint sends this TP to the host if it 
	/// 	cannot return a DP in response to an ACK TP sent by the host.
	/// </summary>
	public class NotReadyPacket : TransactionPacket
	{
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

		public NotReadyPacket () : base(TransactionPacketSubtype.NotReady)
		{
		}

		public NotReadyPacket (uint deviceAddress) : base(TransactionPacketSubtype.NotReady, deviceAddress)
		{
		}

		protected override uint[] InternalData {
			get { return new uint[] { this.Direction.Data | this.EndpointNumber.Data, this.StreamId.Data }; }
		}

		public override string DetailedString {
			get {
				string result = base.DetailedString + "\n";
				result += "Direction: " + this.Direction.Direction.ToString () + "\n";
				result += "Endpoint Number: " + this.EndpointNumber + "\n";
				result += "Stream ID: " + this.StreamId + "\n";
				
				return result;
			}
		}
	}
}

