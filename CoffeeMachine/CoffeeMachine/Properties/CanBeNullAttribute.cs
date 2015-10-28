using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple=false, Inherited=true)]
	public sealed class CanBeNullAttribute : Attribute
	{
		public CanBeNullAttribute()
		{
		}
	}
}