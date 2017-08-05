using Microsoft.Extensions.DependencyInjection;

using Breeze.AddIns.Builder;
using Breeze.AddIns.Builder.Feature;

namespace Breeze.AddIns.Base
{
	internal class BaseFeature : IAppFeature
	{
		private readonly IApp app;

		public BaseFeature(IApp app) 
		{
			this.app = app;
		}
	}

	internal static class BaseFeatureBuilderExtension {
		/// <summary>
		/// Makes the app use all the required features.
		/// </summary>
		/// <param name="addInAppBuilder">Builder responsible for creating the app.</param>
		/// <returns>App builder's interface to allow fluent code.</returns>
		public static IAddInAppBuilder UseBaseFeature(this IAddInAppBuilder addInAppBuilder) {
			addInAppBuilder.ConfigureFeature(features => {
				features
				.AddFeature<BaseFeature>()
				.FeatureServices(services => {
					services.AddSingleton<App>().AddSingleton((provider) => { return provider.GetService<App>() as IApp; });
				});
			});

			return addInAppBuilder;
		}
	}
}
