using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Mobile.View.Converters
{
    public class TextInputToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {


            //if (values[0] is bool && values[1] is bool)
            //{
            //    bool hasText = !(bool)values[0];
            //    bool hasFocus = (bool)values[1];

            //    if (hasFocus || hasText)
            //        return Visibility.Collapsed;
            //}

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}