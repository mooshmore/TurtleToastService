using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Utilities.WPF.Converters
{
    /// <summary>
    /// Converts the object value to a visibility.
    /// </summary>
    /// <remarks>
    /// If the object is null, Visibility.Collapsed is returned; Otherwise Visibility.Visible.
    /// </remarks>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullOrEmptyToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts the object value to a visibility.
        /// </summary>
        /// <remarks>
        /// If the object is null or empty, Visibility.Collapsed is returned; Otherwise Visibility.Visible.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? Visibility.Collapsed : (object)Visibility.Visible;
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete("Not supported")] 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
