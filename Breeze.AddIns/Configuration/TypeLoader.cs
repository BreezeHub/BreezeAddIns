using System;
using System.Linq;
using System.Runtime.Loader;
using System.Reflection;
using Breeze.AddIns.Builder.Feature;
using Breeze.AddIns.Common;
using Breeze.AddIns.Utilities;

namespace Breeze.AddIns.Configuration
{
    internal static class TypeLoader
    {
		public static AddInTypes LoadAddInTypes(DeploymentPackage deploymentPackage) {

			//simple deployment model for PoC where we put everything in a deployment directory.
			//The assembly is loaded from the deployment folder.
			string locationOfApp = Assembly.GetEntryAssembly().Location;
			string locationOfAddIn = locationOfApp.Replace("Breeze.AddIns.App", deploymentPackage.AssemblyName);
			var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(locationOfAddIn);

			Type feature = assembly.GetType(deploymentPackage.FeatureTypeName);
			Guard.Assert(feature != null);
			Guard.Assert(feature.GetTypeInfo().IsClass);
			Guard.Assert(typeof(IAppFeature).IsAssignableFrom(feature));
			Guard.Assert(typeof(IBreezeAddIn).IsAssignableFrom(feature));

			//HACK
			//This is a hack but does not break the PoC
			//This assembly needs to be loaded
			//This issue is resolveable with extra configuration and is to be loaded
			//dynamically without a reference.
			if (deploymentPackage.Name == "AliceAddIn" || deploymentPackage.Name == "BobAddIn") {
				string locationOfAliceBobCommon = locationOfApp.Replace("Breeze.AddIns.App", "AliceBob.Common");
				AssemblyLoadContext.Default.LoadFromAssemblyPath(locationOfAliceBobCommon);
			}

			Type service = ServiceDiscovery.Discover(assembly)[0];
			Guard.Assert(service != null);
			Guard.Assert(service.GetTypeInfo().IsClass);

			var @interface = service.GetTypeInfo().ImplementedInterfaces.ToArray()[0];
			Guard.Assert(@interface != null);
			Guard.Assert(@interface.GetTypeInfo().IsInterface);

			return new AddInTypes(feature, @interface, service);
		}
	}
}