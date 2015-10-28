namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcPartialViewLocationFormatAttribute : Attribute
	{
		public AspMvcPartialViewLocationFormatAttribute(string format)
		{
		}
	}
}