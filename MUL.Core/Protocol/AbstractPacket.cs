using System;
namespace MUL.Core.Protocol
{
	public abstract class AbstractPacket
	{
		/// <summary>
		/// 	The packet's type
		/// </summary>
		public TypeField Type = new TypeField ();
		/// <summary>
		/// 	Every packet carries a link control word
		/// </summary>
		public LinkControlWorld LinkControlWord = new LinkControlWorld ();
		/// <summary>
		/// 	The packet's data in double words
		/// </summary>
		public abstract uint[] PacketData { get; }
		
		public AbstractPacket (PacketType type)
		{
			this.LinkControlWord.ByteOffset = 3;
			this.Type.Type = type;
		}
		
		public override string ToString ()
		{
			uint[] data = PacketData;
			string result = "[";
			result += this.GetType ().Name + ":";
			
			for (int i = data.Length - 1; i >= 0; --i)
				result += " 0x" + data[i].ToString ("X4");
			result += "]";
			return result;
		}
	}
}

