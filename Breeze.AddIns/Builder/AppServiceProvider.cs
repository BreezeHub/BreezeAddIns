using System;
using System.Collections.Generic;

using Breeze.AddIns.Builder.Feature;
using Breeze.AddIns.Utilities;

namespace Breeze.AddIns.Builder
{
	/// <summary>
	/// Provider of access to services and features registered with the app.
	/// </summary>
	public interface IAppServiceProvider {
		/// <summary>List of registered features.</summary>
		IEnumerable<IAppFeature> Features { get; }

		/// <summary>Provider to registered services.</summary>
		IServiceProvider ServiceProvider { get; }
	}

	/// <summary>
	/// Provider of access to services and features registered with the app.
	/// </summary>
	public class AppServiceProvider : IAppServiceProvider {
		/// <summary>List of registered feature types.</summary>
		private readonly List<Type> featureTypes;

		/// <inheritdoc />
		public IEnumerable<IAppFeature> Features {
			get {
				// features are enumerated in the same order 
				// they where registered with the provider
				foreach (var featureDescriptor in this.featureTypes)
					yield return this.ServiceProvider.GetService(featureDescriptor) as IAppFeature;
			}
		}

		/// <inheritdoc />
		public IServiceProvider ServiceProvider { get; }

		/// <summary>
		/// Initializes a new instance of the object with service provider and list of registered feature types.
		/// </summary>
		/// <param name="serviceProvider">Provider to registered services.</param>
		/// <param name="featureTypes">List of registered feature types.</param>
		internal AppServiceProvider(IServiceProvider serviceProvider, List<Type> featureTypes) {
			Guard.NotNull(serviceProvider, nameof(serviceProvider));
			Guard.NotNull(featureTypes, nameof(featureTypes));

			this.ServiceProvider = serviceProvider;
			this.featureTypes = featureTypes;
		}
	}
}
