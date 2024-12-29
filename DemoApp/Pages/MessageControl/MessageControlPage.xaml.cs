using Wpf.Ui.Controls;

namespace TurtleToastService.DemoApp.Pages.MessageControl;

public partial class MessageControlPage : INavigableView<MessageControlViewModel>
{
    public MessageControlViewModel ViewModel { get; }

    public MessageControlPage(MessageControlViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
