using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 	The Type field is a 5-bit field that 
	/// 	identifies the format of the packet. 
	/// 	The type is used to determine how the 
	/// 	packet is to be used or forwarded by 
	/// 	intervening links.
	/// </summary>
	public class TypeField : AbstractField
	{		
		public override int Width {
			get {
				return 5;
			}
		}
	}
}

