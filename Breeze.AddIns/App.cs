using Microsoft.Extensions.Logging;

using Breeze.AddIns.Builder;
using Breeze.AddIns.Utilities;
using Breeze.AddIns.Feature.Logging;

using MyAddIn.Common;
using MoreAddIns.Common;
using MyOtherAddIn.Common;

namespace Breeze.AddIns
{
	internal class App : IApp 
	{
		//Provides both feature and service collections.
		public IAppServiceProvider Services { get; set; }

		private readonly ConsoleLog consoleLog;
		private readonly ILogger logger;

		//These are published services known by the host at
		//compile time.
		private readonly IMyAddInService myAddInService;
		private readonly IMoreAddInsService moreAddInsService;
		private readonly IMyOtherAddInService myOtherAddInService;

		//The Dependency Injection system uses this constructor
		//when addins are used eg when UseAddIns() is specified at
		//startup.
		public App(ConsoleLog consoleLog,
			IMyAddInService myAddInService,
			IMoreAddInsService moreAddInsService,
			IMyOtherAddInService myOtherAddInService)
			: this(consoleLog)
		{
			this.myAddInService = myAddInService;
			this.moreAddInsService = moreAddInsService;
			this.myOtherAddInService = myOtherAddInService;
		}

		//The Injection system selects this constructor if no
		//published addins are used eg. when UseAddIns() is
		//not used.
		public App(ConsoleLog consoleLog) {
			this.consoleLog = consoleLog;
			this.logger = consoleLog.LoggerFactory.CreateLogger<App>();
		}

		public ILogger Log => this.logger;

		//sets up services
		public App Initialize(IAppServiceProvider serviceProvider) {
			Guard.NotNull(serviceProvider, nameof(serviceProvider));
			this.Services = serviceProvider;
			return this;
		}

		public bool LoadAddIn(string name) {
			//Not implemented.  Future idea is to load service only
			//additive addins on the fly.
			return true;
		}

		//asks the known addins to us the shared logger component
		//to say something from inside their addin.
		public void WhoAreYou() {
			this.Log.LogInformation("Who are you?");

			this.myAddInService.Please();
			this.moreAddInsService.Identify();
			this.myOtherAddInService.Yourself();
		}
	}
}