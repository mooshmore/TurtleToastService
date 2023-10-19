using System;
using System.Windows.Data;

namespace Utilities.WPF.Converters
{
    /// <summary>
    /// Converter for inverting the boolean value.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InvertedBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Inverts the boolean value.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => !(bool)value;

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete("Not supported")]
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotSupportedException();
    }
}