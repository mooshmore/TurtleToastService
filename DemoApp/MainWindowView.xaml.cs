using System.Windows;

namespace TurtleToastService.DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
}
