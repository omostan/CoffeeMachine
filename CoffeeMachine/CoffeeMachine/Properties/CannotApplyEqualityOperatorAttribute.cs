using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple=false, Inherited=true)]
	public sealed class CannotApplyEqualityOperatorAttribute : Attribute
	{
		public CannotApplyEqualityOperatorAttribute()
		{
		}
	}
}