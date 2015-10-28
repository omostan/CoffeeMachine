using System;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited=true)]
	public sealed class HtmlAttributeValueAttribute : Attribute
	{
		[NotNull]
		public string Name
		{
			get;
			private set;
		}

		public HtmlAttributeValueAttribute([NotNull] string name)
		{
			this.Name = name;
		}
	}
}