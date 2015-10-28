namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple=false, Inherited=true)]
	public sealed class NotNullAttribute : Attribute
	{
		public NotNullAttribute()
		{
		}
	}
}