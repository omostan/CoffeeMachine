using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public sealed class AspMvcSupressViewErrorAttribute : Attribute
	{
		public AspMvcSupressViewErrorAttribute()
		{
		}
	}
}