using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	Use of this LMP is intended for vendor-specific device 
	/// 	testing and shall not be used during normal operation of the link.
	/// </summary>
	public class VendorDeviceTestPacket : LinkManagementPacket
	{
		/// <summary>
		/// 	Vendor-specific device test. The function of these 8 bits is vendor specific.
		/// </summary>
		public uint VendorDeviceTest = 0;
		
		/// <summary>
		/// 	Vendor-defined data. This value is vendor-defined.
		/// </summary>
		public ulong VendorDefinedData = 0;
		
		public VendorDeviceTestPacket () : base(LinkManagementPacketSubtype.VendorDeviceTest)
		{
		}
		
		/// <summary>
		/// 	Vendor-specific device test. The function of these 8 bits is vendor specific.
		/// </summary>
		protected override uint SubtypeSpecificField {
			get {
				return this.VendorDeviceTest;		
			}
		}
		
		/// <summary>
		/// 	Vendor-defined data. This value is vendor-defined.
		/// </summary>
		protected override uint[] InternalData {
			get {
				return new uint[] { (uint)(this.VendorDefinedData & 0xFFFFFFFFu), (uint)(this.VendorDefinedData >> 32) };
			}
		}
	}
}

