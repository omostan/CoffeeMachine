using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CoffeeMachine.Wpf.Converters
{
	public class StateMachineVisibilityConverter : IValueConverter
	{
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((value?.ToString() ?? string.Empty) == parameter.ToString() ? Visibility.Visible : Visibility.Collapsed);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}