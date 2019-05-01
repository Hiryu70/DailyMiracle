using System;
using System.Globalization;
using Xamarin.Forms;

namespace DailyMiracle
{
    internal class PauseToSignConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pause = (bool) value;
            return pause 
                ? "||" 
                : "|>";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
