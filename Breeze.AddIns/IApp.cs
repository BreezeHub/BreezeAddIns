using Microsoft.Extensions.Logging;

using Breeze.AddIns.Builder;

namespace Breeze.AddIns
{
	/// <summary>
	/// Srevice interface for the main app component.
	/// </summary>
    public interface IApp
    {
		/// <summary>
		/// The logger built from the universal LoggerFactory
		/// for this component.
		/// </summary>
		ILogger Log { get; }

		/// <summary>Access to DI services and features registered 
		/// for the app.</summary>
		IAppServiceProvider Services { get; }
		
		/// <summary>
		/// Not implemented. Future possibility to implmenent 
		/// additive service only addins.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		bool LoadAddIn(string name);
		
		/// <summary>
		/// 
		/// </summary>
		void WhoAreYou();
	}
}
