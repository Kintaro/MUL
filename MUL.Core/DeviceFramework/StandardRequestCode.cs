using System;
namespace MUL.Core.DeviceFramework
{
	public enum StandardRequestCode : byte
	{
		GetStatus = 0x00,
		ClearFeature = 0x01,
		SetFeature = 0x03,
		SetAddress = 0x05,
		GetDescriptor = 0x06,
		SetDescriptor = 0x07,
		GetConfiguration = 0x08,
		SetConfiguration = 0x09,
		GetInterface = 0x0A,
		SetInterface = 0x0B,
		SynchFrame = 0x0C,
		SetSel = 0x30,
		SetIsochDelay = 0x31
	}
}

