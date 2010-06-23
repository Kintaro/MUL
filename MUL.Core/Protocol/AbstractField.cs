using System;
namespace MUL.Core.Protocol
{
	public abstract class AbstractField
	{
		/// <summary>
		/// 	The field's real data (unshifted)
		/// </summary>
		public uint RawData = 0;
		/// <summary>
		/// 	Offset from bit 0
		/// </summary>
		private int offset = 0;
		/// <summary>
		/// 	The packet's byte where this field occurs
		/// </summary>
		private int byteOffset = 0;

		public abstract int Width { get; }

		/// <summary>
		/// 	Offset from bit 0
		/// </summary>
		public int Offset {
			get { return this.offset; }
			set { this.offset = value; }
		}

		/// <summary>
		/// 	The packet's byte where this field occurs
		/// </summary>
		public int ByteOffset {
			get { return this.byteOffset; }
			set { byteOffset = value; }
		}

		public virtual uint Data {
			get { return (uint)((this.RawData & ((1 << this.Width) - 1)) << Offset); }
			set { this.RawData = (uint)(value & ((1 << this.Width) - 1)); }
		}
		
		public override string ToString ()
		{
			return "0x" + this.RawData.ToString ("X");
		}
	}
}

