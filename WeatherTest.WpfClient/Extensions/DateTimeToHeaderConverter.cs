using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WeatherTest.WpfClient.Extensions
{
    public class DateTimeToHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Weather on {((DateTime)value).ToString("dd.MM.yyyy")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
