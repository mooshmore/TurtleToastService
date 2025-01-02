using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TurtleToast.DemoApp.Resources
{
    /// <summary>
    /// Interaction logic for ThemeButton.xaml
    /// </summary>
    public partial class ThemeButton : UserControl
    {
        public ThemeButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register(
                "ButtonBackground",
                typeof(Brush),
                typeof(ThemeButton),
                new PropertyMetadata(Brushes.White));

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ButtonBrushProperty =
            DependencyProperty.Register(
                "ButtonBrush",
                typeof(Brush),
                typeof(ThemeButton),
                new PropertyMetadata(Brushes.Black));

        public Brush ButtonBrush
        {
            get { return (Brush)GetValue(ButtonBrushProperty); }
            set { SetValue(ButtonBrushProperty, value); }
        }


        public static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.Register(
                "ButtonForeground",
                typeof(Brush),
                typeof(ThemeButton),
                new PropertyMetadata(Brushes.White));

        public Brush ButtonForeground
        {
            get { return (Brush)GetValue(ButtonForegroundProperty); }
            set { SetValue(ButtonForegroundProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register(
                "ButtonText",
                typeof(string),
                typeof(ThemeButton),
                new PropertyMetadata("Theme color"));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register(
                "ButtonCommand",
                typeof(ICommand),
                typeof(ThemeButton),
                new PropertyMetadata(null));

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public static readonly DependencyProperty ButtonCommandParameterProperty =
            DependencyProperty.Register(
                "ButtonCommandParameter",
                typeof(object),
                typeof(ThemeButton),
                new PropertyMetadata(null));

        public object ButtonCommandParameter
        {
            get { return GetValue(ButtonCommandParameterProperty); }
            set { SetValue(ButtonCommandParameterProperty, value); }
        }
    }
}
