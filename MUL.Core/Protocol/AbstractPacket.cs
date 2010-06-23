using System;
namespace MUL.Core.Protocol
{
	public abstract class AbstractPacket
	{
		public TypeField Type = new TypeField ();
		public LinkControlWorld LinkControlWord = new LinkControlWorld ();
		public abstract uint[] PacketData { get; }
		
		public AbstractPacket ()
		{
			this.LinkControlWord.ByteOffset = 3;
		}
	}
}

