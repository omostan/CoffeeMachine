using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcAreaMasterLocationFormatAttribute : Attribute
	{
		public AspMvcAreaMasterLocationFormatAttribute(string format)
		{
		}
	}
}