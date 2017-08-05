using Microsoft.Extensions.DependencyInjection;

using Breeze.AddIns.Builder;
using Breeze.AddIns.Builder.Feature;
using Breeze.AddIns.Configuration;
using Breeze.AddIns.Feature.Logging;

namespace Breeze.AddIns.Feature.AddIn {
	/// <summary>
	/// This feature loads all the AddIns specified in
	/// the configuration.
	/// </summary>
	internal class AddInsFeature : IAppFeature {
		ConsoleLog consoleLog;

		public AddInsFeature(ConsoleLog consoleLog)
		{
			this.consoleLog = consoleLog;
		}
	}

	public static class UseAddInFeatureExtension {
		public static IAddInAppBuilder UseAddIns(this IAddInAppBuilder addInAppBuilder, string[] args) {
			addInAppBuilder.ConfigureFeature(features => {
				features
				.AddFeature<AddInsFeature>()
				.FeatureServices(services => {
					services.AddSingleton<AddInService>();
				});
			});

			//load addins indicate as auto addins
			foreach (string name in AutoRegistrations.GetAutoRegistrationNames()) {
				AddInTypes addInTypes = TypeLoader.LoadAddInTypes( NamedAddins.GetDeploymentPackageByName(name) );

				addInAppBuilder.ConfigureFeature(features => {
					features
					.AddFeature(addInTypes.Feature)
					.FeatureServices(services => {
						services.AddSingleton(addInTypes.Interface, addInTypes.Service);
					});
				});
			}
			return addInAppBuilder;
		}
	}
}