using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	All SuperSpeed ports that support downstream port capability 
	/// 	shall be capable of sending this LMP.
	/// 
	/// 	If the port that was to be configured in the upstream facing 
	/// 	mode does not receive this LMP within tPortConfiguration time 
	/// 	after link initialization, then the upstream port shall transition 
	/// 	to SS.Disabled and it shall try and connect at the other 
	/// 	speeds this device supports.
	/// </summary>
	public class PortConfigurationPacket : LinkManagementPacket
	{
		/// <summary>
		/// 	This field describes the link speed at which the upstream 
		/// 	port shall operate. Only one of the bits in this field 
		/// 	shall be set in the Port Configuration LMP sent by the 
		/// 	link partner configured in the downstream mode.
		/// </summary>
		public uint LinkSpeed = 0u;
		
		public PortConfigurationPacket () : base (LinkManagementPacketSubtype.PortConfiguration)
		{
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="linkSpeed">
		/// 	This field describes the link speed at which the upstream port shall operate. 
		/// 	Only one of the bits in this field shall be set in the Port Configuration 
		/// 	LMP sent by the link partner configured in the downstream mode.
		/// </param>
		public PortConfigurationPacket (uint linkSpeed) : this()
		{
			this.LinkSpeed = linkSpeed;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="operateAt5Gbps">
		/// 	This field describes the link speed at which the upstream port 
		/// 	shall operate. Only one of the bits in this field shall be set 
		/// 	in the Port Configuration LMP sent by the link partner configured 
		/// 	in the downstream mode.
		/// </param>
		public PortConfigurationPacket (bool operateAt5Gbps) : this ()
		{
			this.OperateAt5Gbps = operateAt5Gbps;
		}
		
		/// <summary>
		/// 	This field describes the link speed at which the upstream 
		/// 	port shall operate. Only one of the bits in this field 
		/// 	shall be set in the Port Configuration LMP sent by the 
		/// 	link partner configured in the downstream mode.
		/// </summary>
		public bool OperateAt5Gbps
		{
			get { return LinkSpeed != 0u; }
			set { LinkSpeed = value ? 1u : 0u; }
		}
		
		/// <summary>
		/// 	This field describes the link speed at which the upstream 
		/// 	port shall operate. Only one of the bits in this field 
		/// 	shall be set in the Port Configuration LMP sent by the 
		/// 	link partner configured in the downstream mode.
		/// </summary>
		protected override uint SubtypeSpecificField {
			get {
				return this.LinkSpeed;
			}
		}
	}
}

