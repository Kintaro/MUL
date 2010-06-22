using System;
namespace MUL.Core.Protocol
{
	public abstract class AbstractField
	{
		public uint data;
		public int offset;
		
		public abstract int Width { get; }
		
		public int Offset 
		{ 
			get 
			{ 
				return this.Offset;
			} 
			set 
			{ 
				this.offset = value;
			} 
		}  
		
		public virtual uint Data
		{
			get
			{
				return (uint)((this.data & ((1 << this.Width) - 1)) << Offset);
			}
			set
			{
				this.data = (uint)(value & ((1 << this.Width) - 1));
			}
		}
	}
}

