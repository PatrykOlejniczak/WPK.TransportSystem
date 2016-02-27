using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Data;


namespace Mobile.View.Converters
{
    public class IndexFromCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ObservableCollection<object> items = parameter as ObservableCollection<object>;

            if (items != null && value != null)
            {
                return items.IndexOf(value);
            }

            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}