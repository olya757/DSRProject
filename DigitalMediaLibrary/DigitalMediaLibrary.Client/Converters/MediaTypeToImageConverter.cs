using DigitalMediaLibrary.Client.HelpUtils;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DigitalMediaLibrary.Client.Converters
{
    public class MediaTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Extention = (string)value;
            MediaTypeEnum type = FileManager.GetMediaType(Extention);
            switch (type)
            {
                case MediaTypeEnum.audio:return @"ImageSources/audio.png";
                case MediaTypeEnum.picture: return @"ImageSources/picture.png";
                case MediaTypeEnum.video: return @"ImageSources/video.png";
            }
            return @"ImageSources/undefined.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
