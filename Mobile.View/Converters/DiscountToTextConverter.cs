using System;
using Windows.UI.Xaml.Data;

namespace Mobile.View.Converters
{
    public class DiscountToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var id = value as string;

            if(id != null)
            {
                return "discount";
            }

            return "normal";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}
