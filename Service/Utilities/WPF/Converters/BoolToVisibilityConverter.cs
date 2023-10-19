using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Utilities.WPF.Converters
{
    /// <summary>
    /// Converts a boolean value to a visibility.
    /// </summary>
    /// <remarks>
    /// By default - True = Visible, False == Collapsed.
    /// </remarks>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Whether to invert the conversion, that is to make True == Collapsed and False = Visible.
        /// </summary>
        public bool Invert { get; set; } = false;

        /// <summary>
        /// Whether to set the false value to Visibility.Hidden instead of Visibility.Collapsed.
        /// </summary>
        public bool UseHidden { get; set; } = false;

        /// <summary>
        /// Converts the given value to a visibility.
        /// </summary>
        /// <remarks>
        /// By default - True = Visible, False == Collapsed.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Invert)
                value = !(bool)value;

            if ((bool)value)
                return Visibility.Visible;
            else
                return UseHidden ? Visibility.Hidden : Visibility.Collapsed;
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete("Not supported")]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
