using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Mobile.View.Converters
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = value?.ToString();

            if (!String.IsNullOrEmpty(str))
            {
                return Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}
