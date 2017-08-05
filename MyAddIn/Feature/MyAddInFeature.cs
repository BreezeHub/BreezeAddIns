using System;
using Breeze.AddIns.Builder.Feature;
using Breeze.AddIns.Common;

namespace MyAddIn.Feature
{
	/// <summary>
	/// Feature for this AddIn.
	/// </summary>
	public class MyAddInFeature : IAppFeature, IBreezeAddIn
	{
		public MyAddInFeature() 
		{
		}

		public void Start() {
		}
	}
}