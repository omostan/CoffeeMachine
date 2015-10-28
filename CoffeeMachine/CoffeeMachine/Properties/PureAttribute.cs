using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Method, Inherited=true)]
	public sealed class PureAttribute : Attribute
	{
		public PureAttribute()
		{
		}
	}
}