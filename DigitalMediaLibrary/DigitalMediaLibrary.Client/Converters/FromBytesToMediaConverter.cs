using DigitalMediaLibrary.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DigitalMediaLibrary.Client.Converters
{
    public class FromBytesToMediaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;
            var mediaFile = (MediaFileViewModel)value;
            string tempPath = "tempfile"+mediaFile.Extension;
            File.WriteAllBytes(@tempPath, mediaFile.Content);
            return tempPath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
