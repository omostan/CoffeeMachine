using System;

namespace CoffeeMachine.Properties
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcEditorTemplateAttribute : Attribute
	{
		public AspMvcEditorTemplateAttribute()
		{
		}
	}
}