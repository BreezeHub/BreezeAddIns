using System;
using Microsoft.Extensions.Logging;

using Breeze.AddIns.Builder;
using Breeze.AddIns.Feature.AddIn;
using Breeze.AddIns.Feature.Logging;

namespace Breeze.AddIns.App
{
    class Program
    {
		//this app is a Proof of Concept (PoC) for AddIns in the Breeze Framework
		//it closely follows the Breeze DI framework and supports a number of cases
		//for adding features at runtime.

		//It demonstrates the following:
		// - No compile time referencial dependency between main app and addins.
		//	 Addins are instead described in configuration. Optionally add published
		//	 interfaces from addins.
		//   See: compilation module Breeze.AddIns.Configuration.Configuration.cs
		//	 and the published interfaces in the .Common projects for example addins.
		// - An AddIn is packaged into an assembly with its services.
		//	 Services marked with the [BreezeService] attribute are automatically
		//	 loaded from AddIns at injection time.
		//   See: MyAddIn project that is a basic addin with one service.
		// - AddIns can be automatically registered at initial injection.
		//   See: Breeze.AddIns.Configuration.AutoRegistrations and 
		//	 Breeze.AddIns.Feature.AddInsFeature types that demo this concept.
		// - The host can publish its services for external use.
		//   See ILoggerFactory which is used by all addins.
		// - AddIns can use published services provided by the host.
		//   See: all addins use the host provided ConsoleLogFeature.
		// - AddIns can publish their services to be used by the host or by each other.
		//   See: published inerfaces in [addin].Common projects and their use in the
		//	 main App class.


		// - AddIns can be injected and configures without references in the main app.
		//   They can still use the injection system without adding published interfaces
		//	 to the main App project.
		//	 See: AliceAddIn and BobAddIn for two addins that both implement a standard
		//   communication interface, ITalk, without the host knowing the ITalk interface.
		//   (This isn't implemented yet. I need to add a startup scheme via the IBreezeAddIn
		//	 interface to start the services. They won't start automagically because they
		//	 are not referenced anywhere.)

		//Future
		// - Can we load AddIns by command?  Reinjection might not be possible but 
		//	 Service only addings would work. 
		//   see: Breeze.AdddIns.IApp.LoadAddIn(string name)

		//Modifications required to main Breeze framework
		// -  Breeze.AddIns.Builder.Feature.FeatureRegistration and IFeatureCollection 
		//	  was refactored to allow non generic version of registration.
		static void Main(string[] args)
        {
			//create a basic app with no addins
			var basic_app = new AddInAppBuilder()
				.UseConsoleLog()
				.Build();

			basic_app.Log.LogInformation("I'm a basic app with no addins.");

			var app_with_addins = new AddInAppBuilder()
				.UseConsoleLog()
				.UseAddIns(args)
				.Build();

			//ask each addin to say something
			app_with_addins.WhoAreYou();

			Console.ReadKey();
		}
	}
}