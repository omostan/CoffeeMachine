using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
	public sealed class AspMvcViewAttribute : PathReferenceAttribute
	{
		public AspMvcViewAttribute()
		{
		}
	}
}