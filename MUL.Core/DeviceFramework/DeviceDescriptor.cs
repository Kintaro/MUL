using System;
namespace MUL.Core.DeviceFramework
{
	public class DeviceDescriptor : AbstractDescriptor
	{
		/// <summary>
		/// 	USB Specification Release Number in Binary-Coded Decimal 
		/// 	(i.e., 2.10 is 210H). This field identifies the release 
		/// 	of the USB Specification with which the device and 
		/// 	its descriptors are compliant.
		/// </summary>
		public ushort USB { get; set; }
		/// <summary>
		/// 	Class code (assigned by the USB-IF).
		/// 	If this field is reset to zero, each interface within 
		/// 	a configuration specifies its own class information 
		/// 	and the various interfaces operate independently.
		/// 
		/// 	If this field is set to a value between 1 and FEH, 
		/// 	the device supports different class specifications on 
		/// 	different interfaces and the interfaces may not operate 
		/// 	independently. This value identifies the class definition 
		/// 	used for the aggregate interfaces.
		/// 
		/// 	If this field is set to FFH, the device class is vendor-specific.
		/// </summary>
		public byte DeviceClass { get; set; }
		/// <summary>
		/// 	Subclass code (assigned by the USB-IF).
		/// 
		/// 	These codes are qualified by the value of the 
		/// 	bDeviceClass field.
		/// 
		/// 	If the bDeviceClass field is reset to zero, this 
		/// 	field shall also be reset to zero.
		/// 
		/// 	If the bDeviceClass field is not set to FFH, 
		/// 	all values are reserved for assignment by the USB-IF.
		/// </summary>
		public byte DeviceSubClass { get; set; }
		/// <summary>
		/// 	Protocol code (assigned by the USB-IF). These codes are 
		/// 	qualified by the value of the bDeviceClass and the 
		/// 	bDeviceSubClass fields. If a device supports class-specific 
		/// 	protocols on a device basis as opposed to an interface basis, 
		/// 	this code identifies the protocols that the device uses as 
		/// 	defined by the specification of the device class.
		/// 
		/// 	If this field is reset to zero, the device does not use 
		/// 	class- specific protocols on a device basis. However, 
		/// 	it may use class-specific protocols on an interface basis.
		/// 
		/// 	If this field is set to FFH, the device uses a vendor-specific 
		/// 	protocol on a device basis.
		/// </summary>
		public byte DeviceProtocol { get; set; }
		/// <summary>
		/// 	Maximum packet size for endpoint zero. The bMaxPacketSize0 
		/// 	value is used as the exponent for a 2^bMaxPacketSize0 value; 
		/// 	e.g., a bMaxPacketSize0 of 4 means a Max Packet size of 16 (24 → 16).
		/// 
		/// 	09H is the only valid value in this field when operating in SuperSpeed mode.
		/// </summary>
		public byte MaxPacketSize { get; set; }
		/// <summary>
		/// 	Vendor ID (assigned by the USB-IF)
		/// </summary>
		public ushort VendorID { get; set; }
		/// <summary>
		/// 	Product ID (assigned by the manufacturer)
		/// </summary>
		public ushort ProductID { get; set; }
		/// <summary>
		/// 	Device release number in binary-coded decimal
		/// </summary>
		public ushort DeviceID { get; set; }
		/// <summary>
		/// 	Index of string descriptor describing manufacturer
		/// </summary>
		public byte ManufacturerNameIndex { get; set; }
		/// <summary>
		/// 	Index of string descriptor describing product
		/// </summary>
		public byte ProductNameIndex { get; set; }
		/// <summary>
		/// 	Index of string descriptor describing the device’s serial number
		/// </summary>
		public byte SerialNumberIndex { get; set; }
		/// <summary>
		/// 	Number of possible configurations
		/// </summary>
		public byte NumberOfConfigurations { get; set; }
		/// <summary>
		/// 	Returns the USB version as string
		/// </summary>
		public string UsbVersion
		{
			get 
			{
				uint subMinor = (this.USB & 0x0Fu);
				long minor = (this.USB >> 0x04) & 0x0Fu;
				long major1 = (this.USB >> 0x08) & 0x0Fu;
				long major2 = (this.USB >> 0x0C) & 0x0Fu;
				
				return major2 + "" + major1 + "." + minor + "." + subMinor;
			}
		}
	}
}

