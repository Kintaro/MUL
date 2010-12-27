using System;

namespace MUL.Core.Util
{
	public static class Crc5
	{
		public static uint Perform (uint dwInput, int iBitcnt)
		{
			const uint poly5 = (0x05u << (32 - 5));
			uint crc5 = (uint)(0x1fu << (32 - 5));
			uint udata = (dwInput << (32 - iBitcnt));
			
			if ((iBitcnt < 1) || (iBitcnt > 32))
				// Validate iBitcnt
				return 0xFFFFFFFF;
			
			while (iBitcnt-- != 0) {
				// bit4 != bit4?
				if (((udata ^ crc5) & (0x1u << (32 - 1))) != 0) {
					crc5 <<= 1;
					crc5 ^= poly5;
				} else
					crc5 <<= 1;
				
				udata <<= 1;
			}
			
			// Shift back into position
			crc5 >>= (32 - 5);
			
			// Invert contents to generate crc field
			crc5 ^= 0x1f;
			
			return crc5;
		}
	}
}

