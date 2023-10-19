using System.Windows;
using System.Windows.Controls;

namespace Utilities.WPF.Behaviors
{
    /// <summary>
    /// Provides a behavior to set focus on a control by setting the <see cref="FocusProperty"/> to true.
    /// </summary>
    public static class SetFocusBehavior
    {
        /// <summary>
        /// Gets the value of the Focus attached property.
        /// </summary>
        /// <param name="obj">The dependency object to get the property from.</param>
        /// <returns>True if focus should be set; otherwise, false.</returns>
        public static bool GetFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(FocusProperty);
        }

        /// <summary>
        /// Sets the value of the Focus attached property.
        /// </summary>
        /// <param name="obj">The dependency object to set the property on.</param>
        /// <param name="value">True if focus should be set; otherwise, false.</param>
        public static void SetFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(FocusProperty, value);
        }

        /// <summary>
        /// Identifies the Focus attached property.
        /// </summary>
        public static readonly DependencyProperty FocusProperty =
            DependencyProperty.RegisterAttached("Focus", typeof(bool), typeof(SetFocusBehavior), new PropertyMetadata(false, OnFocusPropertyChanged));

        /// <summary>
        /// Handles changes to the Focus property.
        /// </summary>
        /// <param name="d">The dependency object whose property was changed.</param>
        /// <param name="e">The event arguments for the property change.</param>
        private static void OnFocusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ComboBox comboBox && (bool)e.NewValue)
            {
                comboBox.Focus();
                comboBox.IsDropDownOpen = true;
            }
            else if (d is Control control && (bool)e.NewValue)
            {
                control.Focus();
            }
        }
    }
}
