namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple=false, Inherited=true)]
	public sealed class CannotApplyEqualityOperatorAttribute : Attribute
	{
		public CannotApplyEqualityOperatorAttribute()
		{
		}
	}
}