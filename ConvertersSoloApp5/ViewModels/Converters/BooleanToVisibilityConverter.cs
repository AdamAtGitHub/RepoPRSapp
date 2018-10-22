using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ViewModels.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
                              object parameter, string language)
        {
            //another way to check for null value 1st
            if (!(value is bool))
                return Visibility.Collapsed;
           
            //  ? : is a conditional expression (operator)
            //if condition is true ? Then value X :
            //otherwise value Y
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
