using System;
namespace MUL.Core
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class AbstractPacket
	{
		/// <summary>
		/// 
		/// </summary>
		protected PacketType type;
		/// <summary>
		/// 
		/// </summary>
		protected LinkControlWord linkControlWord;
		/// <summary>
		/// 
		/// </summary>
		protected uint crc16;
		
		/// <summary>
		/// 
		/// </summary>
		public PacketType Type
		{
			get { return this.type; }
		 	set { this.type = value; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public LinkControlWord LinkControlWord
		{
			get { return this.linkControlWord; }
		 	set { this.linkControlWord = value; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public uint Crc16
		{
			get { return this.crc16; }
			set { this.crc16 = value; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public abstract uint[] PacketData { get; }
	}
}

