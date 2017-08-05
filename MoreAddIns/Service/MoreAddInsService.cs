using Microsoft.Extensions.Logging;

using Breeze.AddIns.Common;
using MoreAddIns.Common;

namespace MoreAddIns.Service
{
	[BreezeService]
    public class MoreAddInsService : IMoreAddInsService
    {
		private readonly ILogger logger; 

		public MoreAddInsService(ILoggerFactory loggerFactory) {
			this.logger = loggerFactory.CreateLogger<MoreAddInsService>();
		}

		public void Identify() 
		{
			this.logger.LogInformation("Identify!");
		}
	}
}
