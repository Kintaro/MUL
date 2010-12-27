using System;
namespace MUL.Core.Protocol
{
	/// <summary>
	/// 
	/// </summary>
	public class RouteStringField : AbstractField
	{
		public RouteStringField ()
		{
		}
		
		/// <summary>
		/// 
		/// </summary>
		public override int Width {
			get {
				return 20;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index">
		/// A <see cref="System.Int32"/>
		/// </param>
		public byte this[int index]
		{
			get 
			{
				return (byte)((this.Data >> (4 * index)) & 0xF);
			}
			set
			{
				uint mask = ~(uint)(0xF << (4 * index));
				this.Data &= mask;
				this.Data |= (uint)((value & 0x0F) << (4 * index));
			}
		}
	}
}

