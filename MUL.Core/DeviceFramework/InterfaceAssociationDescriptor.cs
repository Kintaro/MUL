using System;
namespace MUL.Core.DeviceFramework
{
	/// <summary>
	/// 	The Interface Association Descriptor is used to describe 
	/// 	that two or more interfaces are associated to the same 
	/// 	function. An “association” includes two or more interfaces 
	/// 	and all of their alternate setting interfaces. A device 
	/// 	must use an Interface Association descriptor for each 
	/// 	device function that requires more than one interface. 
	/// 	An Interface Association descriptor is always returned 
	/// 	as part of the configuration information returned by a 
	/// 	GetDescriptor(Configuration) request. An interface 
	/// 	association descriptor cannot be directly accessed with 
	/// 	a GetDescriptor() or SetDescriptor() request. An interface 
	/// 	association descriptor must be located before the set of 
	/// 	interface descriptors (including all alternate settings) 
	/// 	for the interfaces it associates. All of the interface 
	/// 	numbers in the set of associated interfaces must be 
	/// 	contiguous. The interface association descriptor includes 
	/// 	function class, subclass, and protocol fields. The values 
	/// 	in these fields can be the same as the interface class, 
	/// 	subclass, and protocol values from any one of the associated 
	/// 	interfaces. The preferred implementation, for existing device 
	/// 	classes, is to use the interface class, subclass, and 
	/// 	protocol field values from the first interface in the list 
	/// 	of associated interfaces.
	/// </summary>
	public class InterfaceAssociationDescriptor
	{
		/// <summary>
		/// 	Size of this descriptor in bytes
		/// </summary>
		public byte Length { get; set; }
		/// <summary>
		/// 	INTERFACE ASSOCIATION Descriptor
		/// </summary>
		public byte DescriptorType { get; set; }
		/// <summary>
		/// 	Interface number of the first interface 
		/// 	that is associated with this function
		/// </summary>
		public byte FirstInterface { get; set; }
		/// <summary>
		/// 	Number of contiguous interfaces that 
		/// 	are associated with this function
		/// </summary>
		public byte InterfaceCount { get; set; }
		/// <summary>
		/// 	Class code (assigned by USB-IF). 
		/// 	A value of zero is not allowed in this descriptor.
		/// 
		/// 	If this field is FFH, the function class is 
		/// 	vendor-specific. All other values are reserved 
		/// 	for assignment by the USB-IF.
		/// </summary>
		public byte FunctionClass { get; set; }
		/// <summary>
		/// 	Subclass code (assigned by USB-IF).
		/// 	If the FunctionClass field is not set to FFH, 
		/// 	all values are reserved for assignment by the USB-IF.
		/// </summary>
		public byte FunctionSubClass { get; set; }
		/// <summary>
		/// 	Protocol code (assigned by USB-IF). These codes 
		/// 	are qualified by the values of the FunctionClass and 
		/// 	FunctionSubClass fields.
		/// </summary>
		public byte FunctionProtocol { get; set; }
		/// <summary>
		/// 	Index of string descriptor describing this function
		/// </summary>
		public byte FunctionStringIndex { get; set; }
	}
}

