using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Utilities.WPF.Converters
{
    /// <summary>
    /// Converts a numeric value to a visibility.
    /// </summary>
    /// <example>
    /// By default value >= 0 - Visible, value less than 0 - Collapsed.
    /// </example>
    [ValueConversion(typeof(int), typeof(Visibility))]
    public class NegativeToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Whether to treat zero as a negative value or not. False by default.
        /// </summary>
        public bool ZeroIsNegative { get; set; } = false;

        /// <summary>
        /// Whether to assign the negative value to Collapsed visibility, or the other way around.
        /// </summary>
        public bool NegativeIsCollapsed { get; set; } = true;

        /// <summary>
        /// Converts the given numeric value to a visibility.
        /// </summary>
        /// <example>
        /// By default value >= 0 - Visible, value less than 0 - Collapsed.
        /// </example>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isNegative = false;
            int intValue = (int)value;

            if ((ZeroIsNegative && intValue <= 0) || intValue < 0)
                isNegative = true;

            if (!NegativeIsCollapsed)
                isNegative = !isNegative;

            if (isNegative)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;

        }

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete("Not supported")]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
