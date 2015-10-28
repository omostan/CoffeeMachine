using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcPartialViewLocationFormatAttribute : Attribute
	{
		public AspMvcPartialViewLocationFormatAttribute(string format)
		{
		}
	}
}