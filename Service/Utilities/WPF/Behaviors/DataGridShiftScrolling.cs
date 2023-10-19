using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Utilities.WPF.Behaviors
{
    /// <summary>
    /// Enables horizontal scrolliing with a scroll wheel for dataGrids when holding the shift key.
    /// </summary>
    /// <example>
    /// behaviors:DataGridShiftScrolling.ShiftScrollingEnabled="True"
    /// </example>
    public class DataGridShiftScrolling
    {
        /// <summary>
        /// Sets whether this functionality is enabled on the element.
        /// </summary>
        public static readonly DependencyProperty ShiftScrollingEnabledProperty =
            DependencyProperty.RegisterAttached("ShiftScrollingEnabled", typeof(bool), typeof(DataGridShiftScrolling), new PropertyMetadata(false, OnShiftScrollingEnabledChanged));

        /// <summary>
        /// Returns the <see cref="ShiftScrollingEnabledProperty"/> value for the given dataGrid.
        /// </summary>
        public static bool GetShiftScrollingEnabled(DataGrid dataGrid) => (bool)dataGrid.GetValue(ShiftScrollingEnabledProperty);

        /// <summary>
        /// Sets the <see cref="ShiftScrollingEnabledProperty"/> value for the given dataGrid.
        /// </summary>
        public static void SetShiftScrollingEnabled(DataGrid dataGrid, bool value) => dataGrid.SetValue(ShiftScrollingEnabledProperty, value);

        private static void OnShiftScrollingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is DataGrid dataGrid))
                return;

            if ((bool)e.NewValue)
                dataGrid.PreviewMouseWheel += DataGrid_PreviewMouseWheel;
            else
                dataGrid.PreviewMouseWheel -= DataGrid_PreviewMouseWheel;
        }

        private static void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            ScrollViewer scrollView = FindVisualChild<ScrollViewer>(dataGrid);
            if (Keyboard.Modifiers == ModifierKeys.Shift && scrollView != null)
            {
                e.Handled = true;
                int speed = 64;
                double hChange = e.Delta > 0 ? -speed : speed;
                scrollView.ScrollToHorizontalOffset(scrollView.HorizontalOffset + hChange);
            }
        }

        /// <summary>
        /// Finds the visual child of a element.
        /// Also works for embedded elements, like a scrollViewer inside of a dataGrid.
        /// </summary>
        /// <typeparam name="T">The type of the control to look for.</typeparam>
        /// <param name="control">The control that the element is in.</param>
        /// <returns>The found element.</returns>
        public static T? FindVisualChild<T>(DependencyObject control) where T : DependencyObject
        {
            if (control != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(control, i);
                    if (child != null && child is T element)
                    {
                        return element;
                    }

                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }
    }
}
