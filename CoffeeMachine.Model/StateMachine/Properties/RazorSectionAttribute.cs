namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, Inherited=true)]
	public sealed class RazorSectionAttribute : Attribute
	{
		public RazorSectionAttribute()
		{
		}
	}
}