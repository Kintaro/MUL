using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	The U2 Inactivity Timeout LMP shall be used to define the timeout from U1 to U2, 
	/// 	or the timeout from U0 to U2 if the U1 Inactivity Timeout is disabled. 
	/// 	Refer to Section 10.4.2.1 for details on this LMP.
	/// </summary>
	public class U2InactivityTimeoutPacket : LinkManagementPacket
	{
		/// <summary>
		/// 	These 8 bits represent the U2 Inactivity Timeout value. 
		/// 	The value placed in this field is the same value that is 
		/// 	sent to the hub in a Set Port Feature (PORT_U2_TIMEOUT) command. 
		/// 	Refer to Section 10.14.2.9 for details on the encoding of this field.
		/// </summary>
		public uint U2InactivityTimeout = 0u;
		
		public U2InactivityTimeoutPacket () : base(LinkManagementPacketSubtype.U2InactivityTimeout)
		{
		}
		
		public U2InactivityTimeoutPacket (uint timeout) : this()
		{
			this.U2InactivityTimeout = timeout;
		}
		
		/// <summary>
		/// 	These 8 bits represent the U2 Inactivity Timeout value. 
		/// 	The value placed in this field is the same value that is 
		/// 	sent to the hub in a Set Port Feature (PORT_U2_TIMEOUT) command. 
		/// 	Refer to Section 10.14.2.9 for details on the encoding of this field.
		/// </summary>
		protected override uint SubtypeSpecificField {
			get {
				return this.U2InactivityTimeout;
			}
		}
	}
}



