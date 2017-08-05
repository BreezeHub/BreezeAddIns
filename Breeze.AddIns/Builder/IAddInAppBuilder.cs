using System;
using Microsoft.Extensions.DependencyInjection;

using Breeze.AddIns.Builder.Feature;

namespace Breeze.AddIns.Builder {
	/// <summary>
	/// App builder allows constructing an app using specific components.
	/// </summary>
	public interface IAddInAppBuilder {
		/// <summary>Collection of DI services.</summary>
		IServiceCollection Services { get; }

		/// <summary>
		/// Constructs the app with the required features, services, and settings.
		/// </summary>
		/// <returns>Initialized app.</returns>
		IApp Build();

		/// <summary>
		/// Adds features to the builder. 
		/// </summary>
		/// <param name="configureFeatures">A method that adds features to the collection.</param>
		/// <returns>Interface to allow fluent code.</returns>
		IAddInAppBuilder ConfigureFeature(Action<IFeatureCollection> configureFeatures);

		/// <summary>
		/// Adds services to the builder. 
		/// </summary>
		/// <param name="configureServices">A method that adds services to the builder.</param>
		/// <returns>Interface to allow fluent code.</returns>
		IAddInAppBuilder ConfigureServices(Action<IServiceCollection> configureServices);

		/// <summary>
		/// Add configurations for the service provider.
		/// </summary>
		/// <param name="configure">A method that configures the service provider.</param>
		/// <returns>Interface to allow fluent code.</returns>
		IAddInAppBuilder ConfigureServiceProvider(Action<IServiceProvider> configure);
	}
}