namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple=false, Inherited=true)]
	public sealed class InvokerParameterNameAttribute : Attribute
	{
		public InvokerParameterNameAttribute()
		{
		}
	}
}