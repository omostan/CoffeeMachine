using System;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
	public sealed class StringFormatMethodAttribute : Attribute
	{
		public string FormatParameterName
		{
			get;
			private set;
		}

		public StringFormatMethodAttribute(string formatParameterName)
		{
			this.FormatParameterName = formatParameterName;
		}
	}
}