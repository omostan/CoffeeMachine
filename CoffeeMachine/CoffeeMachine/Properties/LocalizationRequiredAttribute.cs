using System;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple=false, Inherited=true)]
	public sealed class LocalizationRequiredAttribute : Attribute
	{
		public bool Required
		{
			get;
			private set;
		}

		public LocalizationRequiredAttribute() : this(true)
		{
		}

		public LocalizationRequiredAttribute(bool required)
		{
			this.Required = required;
		}
	}
}