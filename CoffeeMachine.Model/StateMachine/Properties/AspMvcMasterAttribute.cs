namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcMasterAttribute : Attribute
	{
		public AspMvcMasterAttribute()
		{
		}
	}
}