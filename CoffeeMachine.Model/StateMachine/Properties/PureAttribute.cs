namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Method, Inherited=true)]
	public sealed class PureAttribute : Attribute
	{
		public PureAttribute()
		{
		}
	}
}