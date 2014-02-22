using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Ru.Rubinst.DocumentApp
{
    public class RadioConverter: IValueConverter
    {
        // bool? -> bool для кнопок
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool?)value;
            var param = Int32.Parse(parameter.ToString());
            switch (param)
            {
                case 0:
                    return val == true;
                case 1:
                    return val == null;
                case 2:
                    return val == false;
            }
            return false;
        }

        // в обратную сторону
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            var param = Int32.Parse(parameter.ToString());
            switch (param)
            {
                case 0:
                    return true;
                case 1:
                    return null;
                case 2:
                    return false;
            }
            return null;
        }
    }
}
