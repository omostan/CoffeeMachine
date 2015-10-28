using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple=false, Inherited=true)]
	public sealed class InvokerParameterNameAttribute : Attribute
	{
		public InvokerParameterNameAttribute()
		{
		}
	}
}