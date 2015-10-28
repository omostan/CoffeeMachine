using System;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcAreaAttribute : PathReferenceAttribute
	{
		[NotNull]
		public string AnonymousProperty
		{
			get;
			private set;
		}

		public AspMvcAreaAttribute()
		{
		}

		public AspMvcAreaAttribute([NotNull] string anonymousProperty)
		{
			this.AnonymousProperty = anonymousProperty;
		}
	}
}