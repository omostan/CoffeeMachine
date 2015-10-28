using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcMasterAttribute : Attribute
	{
		public AspMvcMasterAttribute()
		{
		}
	}
}