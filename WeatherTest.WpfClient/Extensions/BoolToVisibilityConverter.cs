using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WeatherTest.WpfClient.Extensions
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            var isReverse = false;
            if (parameter != null)
            {
                bool.TryParse(parameter.ToString(), out isReverse);
            }
            var result = ((bool)value) ^ isReverse
                ? Visibility.Visible.ToString()
                : Visibility.Hidden.ToString();
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
