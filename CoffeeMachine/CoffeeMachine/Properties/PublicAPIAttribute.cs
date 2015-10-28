using System;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Properties
{
	[MeansImplicitUse]
	public sealed class PublicAPIAttribute : Attribute
	{
		[NotNull]
		public string Comment
		{
			get;
			private set;
		}

		public PublicAPIAttribute()
		{
		}

		public PublicAPIAttribute([NotNull] string comment)
		{
			this.Comment = comment;
		}
	}
}