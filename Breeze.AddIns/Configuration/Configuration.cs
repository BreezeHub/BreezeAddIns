using System.Collections.Generic;

namespace Breeze.AddIns.Configuration
{
	/// <summary>
	/// A simple configuration scheme.  Others are possible such as
	/// a configuration file.
	/// </summary>
	internal static class AutoRegistration
	{
		public static readonly List<string> PackagesByName = new List<string>()
		{
			"MyAddIn",
			"MyOtherAddIn",
			"MoreAddIns",
			"AliceAddIn",
			"BobAddIn"
		};
	}

	//currently the service discovery scheme requires each addin is implemented in a seperate assembly file.
	internal static class NamedAddins
	{
		public static readonly Dictionary<string, DeploymentPackage> DeploymentPackages = new Dictionary<string, DeploymentPackage>()
			{
				["MoreAddIns"] = new DeploymentPackage
				{
					Name = "MoreAddIns",
					AssemblyName = "MoreAddIns",
					FeatureTypeName = "MoreAddIns.Feature.MoreAddInsFeature"
				},
				["MyAddIn"] = new DeploymentPackage 
				{
					Name = "MyAddIn",
					AssemblyName = "MyAddIn",
					FeatureTypeName = "MyAddIn.Feature.MyAddInFeature"
				},
				["MyOtherAddIn"] = new DeploymentPackage 
				{
					Name = "MyOtherAddIn",
					AssemblyName = "MyOtherAddIn",
					FeatureTypeName = "MyOtherAddIn.Feature.MyOtherAddInFeature"
				},
				["AliceAddIn"] = new DeploymentPackage 
				{
					Name = "AliceAddIn",
					AssemblyName = "AliceAddIn",
					FeatureTypeName = "AliceAddIn.Feature.AliceAddInFeature"
				},
				["BobAddIn"] = new DeploymentPackage
				{
					Name = "BobAddIn",
					AssemblyName = "BobAddIn",
					FeatureTypeName = "BobAddIn.Feature.BobAddInFeature"
				}
			};
    }
}
