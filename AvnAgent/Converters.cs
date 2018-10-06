using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AvnAgent
{
    namespace Converters
    {
        /// <summary>
        ///  Represents a converter that converts a String to a Visibility enumeration value, depending on whether the String is empty. 
        /// </summary>
        public class EmptyStringToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value.ToString() == "")
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
