using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Utilities.WPF.Behaviors
{
    /// <summary>
    /// Provides an attached behavior for handling the Window.Closing event and executing a specified command.
    /// </summary>
    public static class WindowClosingBehavior
    {
        /// <summary>
        /// Identifies the DependencyProperty that can be attached to a Window to handle the Closing event.
        /// </summary>
        public static readonly DependencyProperty ClosingProperty = DependencyProperty.RegisterAttached(
            "Closing",
            typeof(ICommand),
            typeof(WindowClosingBehavior),
            new UIPropertyMetadata(new PropertyChangedCallback(ClosingChanged)));

        /// <summary>
        /// Gets the value of the Closing attached property from the specified DependencyObject.
        /// </summary>
        /// <param name="obj">The DependencyObject to get the property value from.</param>
        /// <returns>The ICommand associated with the property.</returns>
        public static ICommand GetClosing(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ClosingProperty);
        }

        /// <summary>
        /// Sets the value of the Closing attached property on the specified DependencyObject.
        /// </summary>
        /// <param name="obj">The DependencyObject to set the property value on.</param>
        /// <param name="value">The ICommand to associate with the property.</param>
        public static void SetClosing(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ClosingProperty, value);
        }

        /// <summary>
        /// Handles the PropertyChanged event of the Closing attached property and subscribes/unsubscribes to the Window.Closing event.
        /// </summary>
        /// <param name="target">The target DependencyObject where the property is attached.</param>
        /// <param name="e">The event data for the PropertyChanged event.</param>
        private static void ClosingChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target is Window window)
            {
                if (e.NewValue != null)
                    window.Closing += Window_Closing;
                else
                    window.Closing -= Window_Closing;
            }
        }

        /// <summary>
        /// Handles the Window.Closing event and executes the associated command if allowed by CanExecute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The CancelEventArgs for the event.</param>
        private static void Window_Closing(object sender, CancelEventArgs e)
        {
            if (sender is Window window)
            {
                var closing = GetClosing(window);
                if (closing != null)
                {
                    if (closing.CanExecute(null))
                        closing.Execute(null);
                    else
                        e.Cancel = true;
                }
            }
        }
    }
}
