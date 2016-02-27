using System;
using Windows.UI.Xaml.Data;

namespace Mobile.View.Converters
{
    public class MinutesFromTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value as TimeSpan?)?.Minutes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}