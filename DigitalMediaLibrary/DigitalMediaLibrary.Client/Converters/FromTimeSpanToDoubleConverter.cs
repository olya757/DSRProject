using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DigitalMediaLibrary.Client.Converters
{
    public class FromTimeSpanToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan)value;
            double milliseconds = time.TotalMilliseconds;
            return milliseconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mills = (double)value;
            var time = new TimeSpan();
            time = TimeSpan.FromMilliseconds(mills);
            return time;
        }
    }
}
