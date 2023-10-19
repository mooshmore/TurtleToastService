using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Utilities.WPF.Converters
{
    /// <summary>
    /// A converter for command binding parameters allowing to use multiple parameters for a single command.
    /// </summary>
    /// <example>
    /// Xaml:
    /// 
    ///     <KeyBinding Command = "{Binding ShortcutKeyOperationCommand}" Gesture="CTRL+E">
    ///         <KeyBinding.CommandParameter>
    ///             <MultiBinding Converter = "{StaticResource PassThrough}">
    ///                 <Binding Path="CurrentCell" ElementName="MonitorDataGrid" Converter="{StaticResource CurentCellToValue}"/>
    ///                 <Binding Source = "{x:Static operationTypes:OperationType.Modify}"/>
    ///             </MultiBinding>
    ///         </KeyBinding.CommandParameter>
    ///     </KeyBinding>
    ///     
    /// C#:
    /// 
    ///     internal static void ShortcutKeyOperation(object parameter)
    ///     {
    ///         var values = (object[])parameter;
    ///         var element = values[0];
    ///         object operationType = (OperationType)values[1];
    ///     }
    /// </example>
    public class PassThroughConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts the parameters to a array.
        /// </summary>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values.ToArray();

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete("Not supported")]
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
