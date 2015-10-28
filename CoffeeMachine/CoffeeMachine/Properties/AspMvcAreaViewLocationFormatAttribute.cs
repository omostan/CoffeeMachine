using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcAreaViewLocationFormatAttribute : Attribute
	{
		public AspMvcAreaViewLocationFormatAttribute(string format)
		{
		}
	}
}