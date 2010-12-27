using System;
using System.Collections.Generic;
using MUL.Core.DeviceFramework;

namespace MUL.Core.IO
{
	/// <summary>
	/// 
	/// </summary>
	public class Device 
	{
		/// <summary>
		/// 
		/// </summary>
		public Device ()
		{
			this.Configurations = new List<StandardConfigurationDescriptor> ();
		}
		
		/// <summary>
		/// 
		/// </summary>
		public DeviceDescriptor DeviceDescriptor { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		public List<StandardConfigurationDescriptor> Configurations { get; }
	}
}

