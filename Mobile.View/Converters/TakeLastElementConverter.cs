using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace Mobile.View.Converters
{
    public class TakeLastElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IEnumerable<object> items = value as IEnumerable<object>;

            if (items != null)
            {
                return items.LastOrDefault();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}