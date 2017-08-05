using Microsoft.Extensions.Logging;

using Breeze.AddIns.Common;
using AliceBob.Common;

namespace AliceAddIn.Service {
	[BreezeService]
	public class AliceService : ITalk {
		private readonly ILogger logger;

		public AliceService(ILoggerFactory loggerFactory) {
			this.logger = loggerFactory.CreateLogger<AliceService>();
		}

		public void SaySomething(string toBob) {
			this.logger.LogInformation(toBob);
		}
	}
}
