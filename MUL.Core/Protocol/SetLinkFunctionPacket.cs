using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	The Set Link Function LMP shall be used to configure 
	/// 	functionality that can be changed without leaving the 
	/// 	active (U0) state.
	/// 	
	/// 	Upon receipt of a LMP with the Force_LinkPM_Accept bit 
	/// 	asserted, the port shall accept all LGO_U1 and LGO_U2 
	/// 	Link Commands until the port receives a LMP with the 
	/// 	Force_LinkPM_Accept bit de-asserted. 
	/// 
	/// 	Note: Improper use of the Force_LinkPM_Accept 
	/// 	functionality can impact the performance of the link 
	/// 	significantly. This capability shall only be used for 
	/// 	compliance and testing purposes. Software must ensure 
	/// 	that there are no pending packets at the link level 
	/// 	before issuing a SetPortFeature command that generates 
	/// 	an LGO_U1 or LGO_U2 link command.
	/// 	
	/// 	This LMP is sent by a hub to a device connected on a 
	/// 	specific port when it receives a SetPortFeature 
	/// 	(FORCE_LINKPM_ACCEPT) command. Refer to Section 10.4.2.2 
	/// 	and Section 10.4.2.9 for more details.
	/// </summary>
	public class SetLinkFunctionPacket : LinkManagementPacket
	{
		private SetLinkFunction linkFunction = SetLinkFunction.ForceLinkPMAccept_Deassert;
		
		public SetLinkFunction SetLinkFunction
		{
			get { return this.linkFunction; }
		}
		
		public override uint[] PacketData {
			get {
				return new uint[] 
				{
					/// <summary>
					/// 	Dword 3
					/// </summary>
					this.FirstPacket,
					/// <summary>
					/// 	Dword 2
					/// </summary>
					0,					
					/// <summary>
					///  	Dword 1
					/// </summary>
					0,
					/// <summary>
					/// 	Dword 0
					/// </summary>
					(uint)(((byte)this.SetLinkFunction << 9) | ((byte)this.SubtypeField.Subtype << 5) | (byte)(this.Type)),
				};
			}
		}
	}
}

