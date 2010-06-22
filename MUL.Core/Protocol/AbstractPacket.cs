using System;
namespace MUL.Core.Protocol
{
	public abstract class AbstractPacket
	{
		public LinkControlWorld LinkControlWord;
		public abstract AbstractField[] PacketData { get; }
	}
}

