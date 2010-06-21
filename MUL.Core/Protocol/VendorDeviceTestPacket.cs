using System;
namespace MUL.Core
{
	/// <summary>
	/// 	Use of this LMP is intended for vendor-specific 
	/// 	device testing and shall not be used during 
	/// 	normal operation of the link.
	/// </summary>
	public class VendorDeviceTestPacket : LinkManagementPacket
	{
		/// <summary>
		/// 	This value is vendor-defined.
		/// </summary>
		private ulong vendorData = 0;
		/// <summary>
		/// 	The function of these 8 bits is vendor specific.
		/// </summary>
		private byte vendorTest = 0;
		
		/// <summary>
		/// 	This value is vendor-defined.
		/// </summary>
		public ulong VendorData {
			get {
				return this.vendorData;
			}
			set {
				vendorData = value;
			}
		}

		/// <summary>
		/// 	The function of these 8 bits is vendor specific.
		/// </summary>
		public byte VendorTest {
			get {
				return this.vendorTest;
			}
			set {
				vendorTest = value;
			}
		}

		public override uint[] PacketData {
			get {
				return new uint[] 
				{
					this.FirstPacket,
					(uint)(this.vendorData >> 32),
					(uint)(this.vendorData & 0xFFFFFFFFu),
					(uint)(((byte)this.vendorTest << 9) | ((byte)this.SubtypeField.Subtype << 5) | (byte)(this.Type)),
				};
			}
		}
	}
}

