using System.Windows;
using System.Windows.Controls;
using TurtleToastService.Service.ToastStyling;

namespace TurtleToastService.Service.ToastHost
{
    /// <summary>
    /// Interaction logic for ToastHostView.xaml
    /// </summary>
    public partial class ToastHostView : UserControl
    {
        /// <summary>
        /// A user control used to host toast messages.
        /// </summary>
        public ToastHostView()
        {
            InitializeComponent();
            this.DataContext = Core.TurtleToastService.ToastHost;

            // Todo: Make it possible to edit toast properties such as border radius, border thickness, 
            // Todo: Add appearing / dissapearing animations?

            ThemeManager.ThemeChanged += ChangeTheme;
            ThemeManager.ChangeTheme(Theme);
        }

        public static readonly DependencyProperty ToastThemeProperty = DependencyProperty.Register(
            "Theme",
            typeof(ToastTheme),
            typeof(UserControl),
            new PropertyMetadata(ToastTheme.Light, OnThemePropertyChanged)
            );

        /// <summary>
        /// A property which holds the app theme.
        /// </summary>
        public ToastTheme Theme
        {
            get => (ToastTheme)GetValue(ToastThemeProperty);
            set
            {
                SetValue(ToastThemeProperty, value);
                ThemeManager.ChangeTheme(value);
            }
        }

        private static void OnThemePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ThemeManager.ChangeTheme((ToastTheme)e.NewValue);
        }

        /// <summary>
        /// Changes the theme by clearing the dicionaries and adding the theme dictionary.
        /// </summary>
        /// <remarks>
        /// This method is feasible as the only dynamic properties of the app are the themes.
        /// </remarks>
        private void ChangeTheme(object? sender, ResourceDictionary e)
        {
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(e);
        }
    }
}
