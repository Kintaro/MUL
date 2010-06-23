using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	Transaction Packets (TPs) traverse the direct path between 
	/// 	the host and a device. TPs are used to control data flow and 
	/// 	manage the end-to-end connection. The value in the Type field 
	/// 	shall be set to Transaction Packet. The Route String field is 
	/// 	used by hubs to route a packet that appears on its upstream port 
	/// 	to the correct downstream port. The route string is set to zero 
	/// 	for a TP sent by a device. When the host sends a TP, the Device 
	/// 	Address field contains the address of the intended recipient. 
	/// 	When a device sends a TP to the host then it sets the Device 
	/// 	Address field to its own address. This field is used by the host 
	/// 	to identify the source of the TP. The SubType field in a TP is 
	/// 	used by the recipient to determine the format and usage of the TP.
	/// </summary>
	public class TransactionPacket : AbstractPacket
	{
		/// <summary>
		/// 	Transaction Packet Subtypes
		/// </summary>
		public enum TransactionPacketSubtype : uint
		{
			/// <summary>
			/// 	Acknowledgement (ACK) Transaction Packet
			/// </summary>
			Acknowledgement = 0x01,
			/// <summary>
			/// 	Not Ready (NRDY) Transaction Packet
			/// </summary>
			NotReady = 0x02,
			/// <summary>
			/// 	Endpoint Ready (ERDY) Transaction Packet
			/// </summary>
			EndpointReady = 0x03,
			/// <summary>
			/// 	STATUS Transaction Packet
			/// </summary>
			Status = 0x04,
			/// <summary>
			/// 	STALL Transaction Packet
			/// </summary>
			Stall = 0x05,
			/// <summary>
			/// 	Device Notification (DEV_NOTIFICATION) Transaction Packet
			/// </summary>
			DeviceNotification = 0x06,
			/// <summary>
			/// 	PING Transaction Packet
			/// </summary>
			Ping = 0x07,
			/// <summary>
			/// 	PING_RESPONSE Transaction Packet
			/// </summary>
			PingResponse = 0x08
		}

		/// <summary>
		/// 	This field defines the direction of an endpoint within 
		/// 	the device that is the source or recipient of this TP. 
		/// 	Refer to Section 8.8.
		/// </summary>
		public enum DirectionType : uint
		{
			HostToDevice = 0x00,
			DeviceToHost = 0x01
		}

		/// <summary>
		/// 	This field specifies the device, via its address, 
		/// 	that is the recipient or the source of the TP. 
		/// 	Refer to Section 8.8.
		/// </summary>
		public class DeviceAddressField : AbstractField
		{
			public DeviceAddressField ()
			{
				this.Offset = 25;
			}

			public override int Width {
				get { return 7; }
			}
		}

		/// <summary>
		/// 	Endpoint Number (Ept Num). This field determines an 
		/// 	endpoint within the device that is the source or r
		/// 	ecipient of this TP. Refer to Section 8.8.
		/// </summary>
		public class EndpointNumberField : AbstractField
		{
			public EndpointNumberField ()
			{
				this.Offset = 8;
			}

			public override int Width {
				get { return 4; }
			}
		}

		/// <summary>
		/// 	If this ACK TP is targeted at a Bulk endpoint, this field 
		/// 	contains a Stream ID value between 1 and 65535. The Stream ID 
		/// 	value of 0 is reserved for Stream pipes. The usage of this 
		/// 	field is class dependent. This field shall be set to zero if 
		/// 	the Bulk endpoint does not support Streams.
		/// </summary>
		public class StreamIdField : AbstractField
		{
			public StreamIdField ()
			{
				this.Offset = 0;
			}

			public override int Width {
				get { return 16; }
			}
		}

		/// <summary>
		/// 	This field defines the direction of an endpoint within 
		/// 	the device that is the source or recipient of this TP. 
		/// 	Refer to Section 8.8.
		/// </summary>
		public class DirectionField : AbstractField
		{
			public DirectionField ()
			{
				this.Offset = 7;
			}

			public override int Width {
				get { return 1; }
			}

			public DirectionType Direction {
				get { return ((DirectionType)this.RawData == DirectionType.DeviceToHost) ? DirectionType.DeviceToHost : DirectionType.HostToDevice; }
				set { this.RawData = (uint)value; }
			}
		}

		protected TransactionPacketSubtype Subtype;
		/// <summary>
		/// 	This field specifies the device, via its address, 
		/// 	that is the recipient or the source of the TP. 
		/// 	Refer to Section 8.8.
		/// </summary>
		public DeviceAddressField DeviceAddress = new DeviceAddressField ();

		protected TransactionPacket (TransactionPacketSubtype subType) : base(PacketType.TransactionPacket)
		{
			this.Subtype = subType;
		}

		protected TransactionPacket (TransactionPacketSubtype subType, uint deviceAddress) : this(subType)
		{
			this.DeviceAddress.Data = deviceAddress;
		}

		public override uint[] PacketData {
			get { return new uint[] { this.Type.Data | this.DeviceAddress.Data, (uint)this.Subtype | this.InternalData[0], this.InternalData[1], this.LinkControlWord.Data }; }
		}

		protected virtual uint[] InternalData {
			get { return new uint[] { 0, 0 }; }
		}

		public override string DetailedString {
			get {
				string result = base.DetailedString + "\n";
				result += "Subtype: " + this.Subtype.ToString () + " Transaction Packet\n";
				result += "Device Address: " + this.DeviceAddress;
				
				return result;
			}
		}
	}
}

