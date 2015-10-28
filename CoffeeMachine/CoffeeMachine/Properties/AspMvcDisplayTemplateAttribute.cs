using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcDisplayTemplateAttribute : Attribute
	{
		public AspMvcDisplayTemplateAttribute()
		{
		}
	}
}