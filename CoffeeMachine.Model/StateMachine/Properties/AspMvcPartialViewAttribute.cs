namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
	public sealed class AspMvcPartialViewAttribute : PathReferenceAttribute
	{
		public AspMvcPartialViewAttribute()
		{
		}
	}
}