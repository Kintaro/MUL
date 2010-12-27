using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	Each endpoint used for an interface has its own 
	/// 	descriptor. This descriptor contains the information 
	/// 	required by the host to determine the bandwidth 
	/// 	requirements of each endpoint. An endpoint descriptor 
	/// 	is always returned as part of the configuration information 
	/// 	returned by a GetDescriptor(Configuration) request. 
	/// 	An endpoint descriptor cannot be directly accessed with 
	/// 	a GetDescriptor() or SetDescriptor() request. There is 
	/// 	never an endpoint descriptor for endpoint zero.
	/// </summary>
	public class EndPointDescriptor : AbstractDescriptor
	{
		/// <summary>
		/// 
		/// </summary>
		public enum EndpointDirection : byte
		{
			Out = 0x00,
			In = 0x01,
		}
		/// <summary>
		/// 
		/// </summary>
		public enum TransferTypeEnum : byte 
		{
			Control = 0x00,
			Isochronous = 0x01,
			Bulk = 0x02,
			Interrupt = 0x03,
		}
		/// <summary>
		/// 
		/// </summary>
		public enum InterruptUsageTypeEnum
		{
			Periodic = 0x00,
			Notification = 0x01,
			Reserved1 = 0x02,
			Reserved2 = 0x03,
		}
		/// <summary>
		/// 
		/// </summary>
		public enum IsochronousUsageTypeEnum
		{
			DataEndpoint = 0x00,
			FeedbackEndpoint = 0x01,
			ImplicitFeedbackDataEndpoint = 0x02,
			Reserved = 0x03,
		}
		/// <summary>
		/// 
		/// </summary>
		public enum SynchronizationTypeEnum
		{
			NoSynchronization = 0x00,
			Asynchronous = 0x01,
			Adaptive = 0x02,
			Synchronous = 0x03,
		}
		/// <summary>
		/// 	The address of the endpoint on the device 
		/// 	described by this descriptor. The address is encoded as follows:
		/// 
		/// 	Bit 3...0: The endpoint number 
		/// 	Bit 6...4: Reserved, reset to zero 
		/// 	Bit 7:	Direction, ignored for control endpoints 
		/// 		0 = OUT endpoint 
		/// 		1 = IN endpoint
		/// </summary>
		public byte EndpointAddress { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public byte EndpointNumber
		{
			get { return (byte)(EndpointAddress & 0xF); }
		}
		/// <summary>
		/// 	This field describes the endpoint’s attributes when it is 
		/// 	configured using the bConfigurationValue.
		/// 	
		/// 	Bits 1..0: Transfer Type 
		/// 		00 = Control 
		/// 		01 = Isochronous 
		/// 		10 = Bulk
		/// 		11 = Interrupt 
		/// 
		/// 	If an interrupt endpoint, bits 5..2 are defined as follows:
		/// 		Bits 3..2: Reserved 
		/// 		Bits 5..4: Usage Type
		/// 			00 = Periodic 
		/// 			01 = Notification 
		/// 			10 = Reserved 
		/// 			11 = Reserved
		/// 
		/// 	If isochronous, they are defined as follows: 
		/// 		Bits 3..2: Synchronization Type
		/// 			00 = No Synchronization 
		/// 			01 = Asynchronous 
		/// 			10 = Adaptive 
		/// 			11 = Synchronous
		/// 		Bits 5..4: Usage Type
		/// 			00 = Data endpoint 
		/// 			01 = Feedback endpoint 
		/// 			10 = Implicit feedback Data endpoint 
		/// 			11 = Reserved
		/// 
		/// 	If not an isochronous or interrupt endpoint, bits 5..2 
		/// 	are reserved and shall be set to zero.
		/// 	All other bits are reserved and shall be reset to zero. 
		/// 	Reserved bits shall be ignored by the host.
		/// </summary>
		public byte Attributes { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public TransferTypeEnum TransferType 
		{
			get { return (TransferTypeEnum)(this.Attributes & 0x03); }
		}
		/// <summary>
		/// 
		/// </summary>
		public InterruptUsageTypeEnum InterruptUsageType
		{
			get { 
				if (this.TransferType != EndPointDescriptor.TransferTypeEnum.Interrupt)
					throw new NotSupportedException ("InterruptUsageType is only supported for Interrupts");
				return (InterruptUsageTypeEnum)((this.Attributes & 0x30) >> 4); 
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public IsochronousUsageTypeEnum IsochronousUsageType
		{
			get { 
				if (this.TransferType != EndPointDescriptor.TransferTypeEnum.Isochronous)
					throw new NotSupportedException ("IsochronousUsageType is only supported for Isochronous");
				return (IsochronousUsageTypeEnum)((this.Attributes & 0x30) >> 4); 
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public SynchronizationTypeEnum SynchronizationType
		{
			get { 
				if (this.TransferType != EndPointDescriptor.TransferTypeEnum.Isochronous)
					throw new NotSupportedException ("SynchronizationType is only supported for Isochronous");
				return (SynchronizationTypeEnum)((this.Attributes & 0xC) >> 2); 
			}
		}
		/// <summary>
		/// 	Maximum packet size this endpoint is capable of 
		/// 	sending or receiving when this configuration is selected.
		/// 
		/// 	There are only two legal values for this field. For control
		/// 	endpoints this field shall be set to 512. For bulk endpoint 
		/// 	types this field shall be set to 1024.
		/// 
		/// 	For interrupt and isochronous endpoints this field shall be 
		/// 	set to 1024 if this endpoint defines a value in the MaxBurst 
		/// 	field greater than zero. If the value in the MaxBurst field 
		/// 	is set to zero then this field can have any value from 0 to 1024 
		/// 	for an isochronous endpoint and 1 to 1024 for an interrupt endpoint.
		/// </summary>
		public byte MaxPacketSize { get; set; }
		/// <summary>
		/// 	Interval for servicing the endpoint for data transfers. 
		/// 	Expressed in 125-µs units.For SuperSpeed isochronous 
		/// 	and interrupt endpoints, this value shall be in the range 
		/// 	from 1 to 16. The bInterval value is used as the exponent for 
		/// 	a 2^(bInterval-1) value; e.g., a bInterval of 4 means a period 
		/// 	of 8 (2^(4-1) → 2^3 → 8).
		/// 
		/// 	This field is reserved and shall not be used for 
		/// 	SuperSpeed bulk or control endpoints.
		/// </summary>
		public byte Interval { get; set; }
	}
}

