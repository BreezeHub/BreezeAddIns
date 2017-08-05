using Microsoft.Extensions.Logging;

using Breeze.AddIns.Common;
using MyOtherAddIn.Common;

namespace MyOtherAddIn.Service
{
	[BreezeService]
	public class MyOtherAddInService : IMyOtherAddInService {
		private readonly ILogger logger;

		public MyOtherAddInService(ILoggerFactory loggerFactory) {
			this.logger = loggerFactory.CreateLogger<MyOtherAddInService>();
		}

		public void Yourself() {
			this.logger.LogInformation("Yourself!");
		}
	}
}
