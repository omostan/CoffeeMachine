using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcViewLocationFormatAttribute : Attribute
	{
		public AspMvcViewLocationFormatAttribute(string format)
		{
		}
	}
}