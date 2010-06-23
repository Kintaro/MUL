using System;
namespace MUL.Core.Protocol
{
	public class SetLinkFunctionPacket : LinkManagementPacket
	{
		
		public enum SetLinkFunctionType : uint
		{
			DeAssert = 0,
			Assert = 1,
		}
		
		public SetLinkFunctionType SetLinkFunction = SetLinkFunctionType.DeAssert;
		
		protected override uint SubtypeSpecificField {
			get {
				return (uint)SetLinkFunction << 1;
			}
		}
	}
}

