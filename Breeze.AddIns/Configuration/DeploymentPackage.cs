
namespace Breeze.AddIns.Configuration
{
    internal class DeploymentPackage
    {
		/// <summary>
		/// Short Name of the addin used to identify addin
		/// in the config.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// AssemblyName where the feature type resides.
		/// </summary>
		public string AssemblyName { get; set; }

		/// <summary>
		/// Features must support IAppFeature and
		/// Breeze.AddIns.Common.IBreezeAddIn.
		/// </summary>
		public string FeatureTypeName { get; set; }
    }
}
