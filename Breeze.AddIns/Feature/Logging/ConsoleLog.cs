using Microsoft.Extensions.Logging;

namespace Breeze.AddIns.Feature.Logging
{
	//Service that holds the universal logger injected
	//into all addins.
	internal class ConsoleLog
	{
		private readonly ILoggerFactory loggerFactory;
		private readonly ILogger logger;

		public ILogger Logger 
		{
			get 
			{
				return this.logger;
			}
		}

		public ILoggerFactory LoggerFactory {
			get {
				return this.loggerFactory;
			}
		}

		public ConsoleLog(ILoggerFactory loggerFactory) {
			this.loggerFactory = loggerFactory;
			this.loggerFactory.AddConsole();
			this.logger = loggerFactory.CreateLogger<ConsoleLog>();
		}
	}
}
