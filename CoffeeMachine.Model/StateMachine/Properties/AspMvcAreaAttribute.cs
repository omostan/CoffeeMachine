namespace CoffeeMachine.Model.StateMachine.Properties
{
    using System;

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