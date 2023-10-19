using System;
using System.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Utilities.WPF.Converters
{
    /// <summary>
    /// A WPF functionality that allows to convert a Current Cell to a cells bound value.
    /// </summary>
    [ValueConversion(typeof(DataGridCellInfo), typeof(object))]
    public class CellToValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts the current cells value to the cells bound value.
        /// </summary>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            DataGridCellInfo cellInfo = (DataGridCellInfo)value;

            if (cellInfo.Column == null)
                return null;

            int columnIndex = cellInfo.Column.DisplayIndex;
            DataRow dataRow = ((DataRowView)cellInfo.Item).Row;
            return dataRow.ItemArray[columnIndex];
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete("Not supported")]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
