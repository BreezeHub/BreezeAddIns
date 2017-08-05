using System.Collections.Generic;

namespace Breeze.AddIns.Configuration
{
	/// <summary>
	/// A simple configuration scheme.  Others are possible such as
	/// a configuration file.
	/// </summary>
	internal static class AutoRegistrations 
	{
		private static List<string> packageNames = new List<string>();

		static AutoRegistrations() 
		{
			AutoRegistrations.packageNames.AddRange(new string[] { "MyAddIn", "MyOtherAddIn", "MoreAddIns", "AliceAddIn", "BobAddIn" });
		}

		public static IEnumerable<string> GetAutoRegistrationNames()
		{
			return AutoRegistrations.packageNames.ToArray();
		}
	}

	//currently the service discovery scheme requires each addin is implemented in a seperate assembly file.
	internal static class NamedAddins
    {
		private static Dictionary<string, DeploymentPackage> namedPackagesDictionary = new Dictionary<string, DeploymentPackage>();

		public static DeploymentPackage GetDeploymentPackageByName(string name) {
			return namedPackagesDictionary[name];
		}

		static NamedAddins() {
			NamedAddins.namedPackagesDictionary.Add("MoreAddIns", new DeploymentPackage {
				Name = "MoreAddIns",
				AssemblyName = "MoreAddIns",
				FeatureTypeName = "MoreAddIns.Feature.MoreAddInsFeature" });

			NamedAddins.namedPackagesDictionary.Add("MyAddIn", new DeploymentPackage {
				Name = "MyAddIn",
				AssemblyName = "MyAddIn",
				FeatureTypeName ="MyAddIn.Feature.MyAddInFeature" });

			NamedAddins.namedPackagesDictionary.Add("MyOtherAddIn", new DeploymentPackage {
				Name = "MyOtherAddIn",
				AssemblyName = "MyOtherAddIn",
				FeatureTypeName = "MyOtherAddIn.Feature.MyOtherAddInFeature" });

			NamedAddins.namedPackagesDictionary.Add("AliceAddIn", new DeploymentPackage {
				Name = "AliceAddIn",
				AssemblyName = "AliceAddIn",
				FeatureTypeName = "AliceAddIn.Feature.AliceAddInFeature" });

			NamedAddins.namedPackagesDictionary.Add("BobAddIn", new DeploymentPackage {
				Name = "BobAddIn",
				AssemblyName = "BobAddIn",
				FeatureTypeName = "BobAddIn.Feature.BobAddInFeature" });
		}
    }
}
