using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcAreaPartialViewLocationFormatAttribute : Attribute
	{
		public AspMvcAreaPartialViewLocationFormatAttribute(string format)
		{
		}
	}
}