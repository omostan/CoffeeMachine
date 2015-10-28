using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter, Inherited=true)]
	public sealed class InstantHandleAttribute : Attribute
	{
		public InstantHandleAttribute()
		{
		}
	}
}