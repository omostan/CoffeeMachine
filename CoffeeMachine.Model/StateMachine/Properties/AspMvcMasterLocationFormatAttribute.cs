namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)]
	public sealed class AspMvcMasterLocationFormatAttribute : Attribute
	{
		public AspMvcMasterLocationFormatAttribute(string format)
		{
		}
	}
}