namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcTemplateAttribute : Attribute
	{
		public AspMvcTemplateAttribute()
		{
		}
	}
}