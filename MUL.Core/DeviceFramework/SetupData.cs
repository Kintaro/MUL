using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	All devices respond to requests from the host on the 
	/// 	device’s Default Control Pipe. These requests are made 
	/// 	using control transfers. The request and the request’s 
	/// 	parameters are sent to the device in the Setup packet. 
	/// 	The host is responsible for establishing the values 
	/// 	passed in the fields listed in Table 9-2. Every 
	/// 	Setup packet has 8 bytes.
	/// </summary>
	public class SetupData
	{
		/// <summary>
		/// 
		/// </summary>
		public class RequestTypeField
		{
			/// <summary>
			/// 
			/// </summary>
			public enum DataTransferDirectionType : byte
			{
				HostToDevice = 0x0,
				DeviceToHost = 0x1
			}

			/// <summary>
			/// 
			/// </summary>
			public enum RequestType
			{
				Standard = 0x0,
				Class = 0x1,
				Vendor = 0x2,
				Reserved = 0x3
			}

			/// <summary>
			/// 
			/// </summary>
			public enum RecipientType
			{
				Device = 0x0,
				Interface = 0x1,
				Endpoint = 0x2,
				Other = 0x3
			}

			/// <summary>
			/// 
			/// </summary>
			private byte data = 0;

			/// <summary>
			/// 
			/// </summary>
			public DataTransferDirectionType DataTransferDirection {
				get { return (DataTransferDirectionType)(((byte)this.data >> 0x07) & 0x01); }
				set {
					this.data &= 0x7F;
					this.data |= (byte)((byte)value << 0x07);
				}
			}
			/// <summary>
			/// 
			/// </summary>
			public RequestType Type {
				get { return (RequestType)(((byte)this.data >> 0x05) & 0x03); }
				set {
					this.data &= 0x9F;
					this.data |= (byte)((byte)value << 0x05);
				}
			}
			/// <summary>
			/// 
			/// </summary>
			public RecipientType Recipient {
				get { return (RecipientType)((byte)this.data & 0x1F); }
				set {
					this.data &= 0xE0;
					this.data |= (byte)value;
				}
			}
			/// <summary>
			/// 
			/// </summary>
			public byte Data {
				get { return this.data; }
				set { this.data = value; }
			}
		}
		
		/// <summary>
		/// 	Characteristics of request:
		/// </summary>
		public RequestTypeField RequestType { get; set; }
		/// <summary>
		/// 	Specific request (refer to Table 9-3)
		/// </summary>
		public StandardRequestCode Request { get; set; }
		/// <summary>
		/// 	Word-sized field that varies according to request
		/// </summary>
		public ushort Value { get; set; }
		/// <summary>
		/// 	Word-sized field that varies according to request; 
		/// 	typically used to pass an index or offset
		/// </summary>
		public ushort Index { get; set; }
		/// <summary>
		/// 	Number of bytes to transfer if there is a Data stage
		/// </summary>
		public ushort Length { get; set; }
	}
}

