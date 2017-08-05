using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

using Breeze.AddIns.Base;
using Breeze.AddIns.Builder.Feature;
using Breeze.AddIns.Utilities;

namespace Breeze.AddIns.Builder {
	public class AddInAppBuilder : IAddInAppBuilder{
		/// <summary>true if the Build method has been called already 
		/// (whether it succeeded or not), false otherwise.</summary>
		private bool built;

		/// <summary>List of delegates that configure the service providers.</summary>
		private readonly List<Action<IServiceProvider>> configureDelegates;

		/// <summary>List of delegates that add services to the builder.</summary>
		private readonly List<Action<IServiceCollection>> configureServicesDelegates;

		/// <summary>List of delegates that add features to the collection.</summary>
		private readonly List<Action<IFeatureCollection>> featuresRegistrationDelegates;

		/// <summary>Collection of DI services.</summary>
		public IServiceCollection Services { get; private set; }

		/// <summary>Collection of features available to and/or used by the node.</summary>
		public IFeatureCollection Features { get; }

		public AddInAppBuilder(List<Action<IServiceCollection>> configureServicesDelegates, List<Action<IServiceProvider>> configureDelegates,
			List<Action<IFeatureCollection>> featuresRegistrationDelegates, IFeatureCollection features) {

			Guard.NotNull(configureServicesDelegates, nameof(configureServicesDelegates));
			Guard.NotNull(configureDelegates, nameof(configureDelegates));
			Guard.NotNull(featuresRegistrationDelegates, nameof(featuresRegistrationDelegates));
			Guard.NotNull(features, nameof(features));

			this.configureServicesDelegates = configureServicesDelegates;
			this.configureDelegates = configureDelegates;
			this.featuresRegistrationDelegates = featuresRegistrationDelegates;
			this.Features = features;

			this.UseBaseFeature();
		}

		public AddInAppBuilder() 
			: this(new List<Action<IServiceCollection>>(),
				new List<Action<IServiceProvider>>(),
				new List<Action<IFeatureCollection>>(),
				new FeatureCollection())
		{
		}

		public IApp Build() 
			{
			if (this.built)
				throw new InvalidOperationException("app already built");
			this.built = true;

			this.Services = this.BuildServices();

			var appServiceProvider = this.Services.BuildServiceProvider();
			this.ConfigureServices(appServiceProvider);

			var app = appServiceProvider.GetService<App>();
			if (app == null)
				throw new InvalidOperationException("app not registered with provider");

			app.Initialize(new AppServiceProvider(
			   appServiceProvider,
			   this.Features.FeatureRegistrations.Select(s => s.FeatureType).ToList()));

			return app;
		}

		/// <summary>
		/// Constructs and configures services ands features to be used by the app.
		/// </summary>
		/// <returns>Collection of registered services.</returns>
		private IServiceCollection BuildServices() {
			this.Services = new ServiceCollection();

			// register services before features 
			// as some of the features may depend on independent services
			foreach (var configureServices in this.configureServicesDelegates)
				configureServices(this.Services);

			// configure features
			foreach (var configureFeature in this.featuresRegistrationDelegates)
				configureFeature(this.Features);

			// configure features startup
			foreach (var featureRegistration in this.Features.FeatureRegistrations)
				featureRegistration.BuildFeature(this.Services);

			return this.Services;
		}

		/// <summary>
		/// Configure registered services.
		/// </summary>
		/// <param name="serviceProvider"></param>
		private void ConfigureServices(IServiceProvider serviceProvider) {
			foreach (var configure in this.configureDelegates)
				configure(serviceProvider);
		}

		public IAddInAppBuilder ConfigureFeature(Action<IFeatureCollection> configureFeatures) {
			Guard.NotNull(configureFeatures, nameof(configureFeatures));

			this.featuresRegistrationDelegates.Add(configureFeatures);
			return this;
		}

		public IAddInAppBuilder ConfigureServices(Action<IServiceCollection> configureServices) {
			Guard.NotNull(configureServices, nameof(configureServices));

			this.configureServicesDelegates.Add(configureServices);
			return this;
		}

		public IAddInAppBuilder ConfigureServiceProvider(Action<IServiceProvider> configure) {
			Guard.NotNull(configure, nameof(configure));

			this.configureDelegates.Add(configure);
			return this;
		}
	}
}