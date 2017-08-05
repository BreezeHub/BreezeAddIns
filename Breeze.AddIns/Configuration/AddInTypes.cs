using System;

namespace Breeze.AddIns.Configuration
{
    internal class AddInTypes
    {
		public Type Feature { get; private set; }
		public Type Interface { get; private set; }
		public Type Service { get; private set; }

		public AddInTypes(Type feature, Type @interface, Type service) {
			this.Feature = feature;
			this.Interface = @interface;
			this.Service = service;
		}
	}
}
