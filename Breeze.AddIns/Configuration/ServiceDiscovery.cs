using System;
using System.Linq;
using System.Reflection;

using Breeze.AddIns.Common;

namespace Breeze.AddIns.Configuration
{
	//This simple service discovery scheme searches for the
	//[BreezeService] attribute on the designated service class
	//in the add in.  As a consequence we only support one
	//service class per addin feature class by selecting Type[0].
	
	//a better, faster, service discovery would be a Services
	//property on IBreezeAddIn that requires AddIns to expose
	//their service types.
    internal static class ServiceDiscovery
    {
		public static Type[] Discover(Assembly a) => a.DefinedTypes
				.Where(t => t.IsDefined(typeof(BreezeServiceAttribute), true))
				.Select(t => t.AsType())
				.ToArray<Type>();
    }
}
