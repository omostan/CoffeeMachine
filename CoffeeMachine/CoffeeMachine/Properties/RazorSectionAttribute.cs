using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, Inherited=true)]
	public sealed class RazorSectionAttribute : Attribute
	{
		public RazorSectionAttribute()
		{
		}
	}
}