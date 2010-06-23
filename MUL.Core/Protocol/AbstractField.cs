using System;
namespace MUL.Core.Protocol
{
	public abstract class AbstractField
	{
		public uint data = 0;
		public int offset = 0;
		public int byteOffset = 0;

		public abstract int Width { get; }

		public int Offset {
			get { return this.offset; }
			set { this.offset = value; }
		}

		public int ByteOffset {
			get { return this.byteOffset; }
			set { byteOffset = value; }
		}

		public virtual uint Data {
			get { return (uint)((this.data & ((1 << this.Width) - 1)) << Offset); }
			set { this.data = (uint)(value & ((1 << this.Width) - 1)); }
		}
	}
}

