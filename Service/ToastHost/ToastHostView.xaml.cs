using System.Windows.Controls;

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
            this.DataContext = Service.TurtleToastService.ToastHost;
        }
    }
}
