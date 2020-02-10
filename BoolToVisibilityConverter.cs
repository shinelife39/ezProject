using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Common
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            if (parameter != null && parameter.ToString().ToUpper().Equals("R"))
            {
                //parameter 넘어올때
                return flag ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                //parameter 안 넘어올때
                return flag ? Visibility.Visible : Visibility.Collapsed;
            }           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
