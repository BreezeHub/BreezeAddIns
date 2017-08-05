using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Breeze.AddIns.Builder;
using Breeze.AddIns.Builder.Feature;

namespace Breeze.AddIns.Feature.Logging {
	/// <summary>
	/// A simple feature that logs to the console.
	/// This is a demo Feature and not meant to be a 
	/// recommended way to support logging in an app.
	/// </summary>
	internal class ConsoleLogFeature : IAppFeature {
		private readonly ConsoleLog consoleLog;

		public ConsoleLogFeature(ConsoleLog consoleLog) {
			this.consoleLog = consoleLog;
		}
	}

	public static class UseConsoleLogFeatureExtension {
		public static IAddInAppBuilder UseConsoleLog(this IAddInAppBuilder addInAppBuilder) {
			addInAppBuilder.ConfigureFeature(features => {
				features
				.AddFeature<ConsoleLogFeature>()
				.FeatureServices(services => {
					services.AddSingleton<ConsoleLog>();
					services.AddSingleton<ILoggerFactory, LoggerFactory>();
				});
			});
			return addInAppBuilder;
		}
	}
}
