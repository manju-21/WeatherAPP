using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Weatherapp.ViewModel.Converter
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;
            if (isRaining == true)
                return "Currently its raining  :)";
            return "Currently its not raininng    :(";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isRaining = (string)value;
            if (isRaining == "Currently Raining")
                return true;
            return false;
        }
    }
}
