using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Utilities.WPF.Behaviors
{
    /// <summary>
    /// A behavior for a textBox that selects all text inside of the textbox when it gets focus.
    /// </summary>
    public class SelectAllTextOnFocus
    {
        /// <summary>
        /// Controls whether this behavior is enabled or not.
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnabled", typeof(bool), typeof(SelectAllTextOnFocus),
                new PropertyMetadata(false, OnIsEnabledChanged));

        /// <summary>
        /// Returns the value of <see cref="IsEnabledProperty"/> of the given object.
        /// </summary>
        public static bool GetIsEnabled(DependencyObject obj) => (bool)obj.GetValue(IsEnabledProperty);

        /// <summary>
        /// Sets the value of <see cref="IsEnabledProperty"/> for the given object.
        /// </summary>
        public static void SetIsEnabled(DependencyObject obj, bool value) => obj.SetValue(IsEnabledProperty, value);

        private static void OnIsEnabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is TextBox textBox))
                return;

            if ((bool)e.NewValue)
            {
                textBox.GotFocus += TextBoxOnGotFocus;
                textBox.SelectAll();
            }
            else
                textBox.GotFocus -= TextBoxOnGotFocus;
        }

        private static async void TextBoxOnGotFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox textBox))
                return;

            // A small delay is needed for the textbox to finish the "focusing" action,
            // which would otherwise remove the selection
            await Task.Delay(10);

            textBox.SelectAll();
        }
    }
}
