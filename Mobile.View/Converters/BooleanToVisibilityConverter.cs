﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Mobile.View.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = value is bool;

            if (val)
            {
                if ((bool)value)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}