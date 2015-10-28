using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcTemplateAttribute : Attribute
	{
		public AspMvcTemplateAttribute()
		{
		}
	}
}