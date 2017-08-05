using Microsoft.Extensions.Logging;

using Breeze.AddIns.Common;
using MyAddIn.Common;

namespace MyAddIn.Service {

	[BreezeService]
	public class MyAddInService : IMyAddInService {
		private readonly ILogger logger;

		public MyAddInService(ILoggerFactory loggerFactory) {
			this.logger = loggerFactory.CreateLogger<MyAddInService>();
		}

		public void Please() {
			this.logger.LogInformation("Please!");
		}
	}
}