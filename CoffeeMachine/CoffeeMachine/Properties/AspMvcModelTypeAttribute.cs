using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcModelTypeAttribute : Attribute
	{
		public AspMvcModelTypeAttribute()
		{
		}
	}
}