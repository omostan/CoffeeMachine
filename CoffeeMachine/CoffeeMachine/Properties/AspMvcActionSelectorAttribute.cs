using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public sealed class AspMvcActionSelectorAttribute : Attribute
	{
		public AspMvcActionSelectorAttribute()
		{
		}
	}
}