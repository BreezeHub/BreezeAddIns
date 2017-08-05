using Microsoft.Extensions.Logging;

using Breeze.AddIns.Common;
using AliceBob.Common;

namespace BobAddIn.Service
{
	[BreezeService]
	public class BobService : ITalk {
		private readonly ILogger logger;

		public BobService(ILoggerFactory loggerFactory) {
			this.logger = loggerFactory.CreateLogger<BobService>();
		}

		public void SaySomething(string receivedFromAlice) {
			this.logger.LogInformation(receivedFromAlice);
		}
	}
}
