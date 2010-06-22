using System;
namespace MUL.Core.Protocol
{
	public class Crc5Field : AbstractField
	{
		public override int Width {
			get { return 5; }
		}
	}
}

