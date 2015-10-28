namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
	public sealed class AspMvcViewAttribute : PathReferenceAttribute
	{
		public AspMvcViewAttribute()
		{
		}
	}
}