using CommunityToolkit.Mvvm.Input;
using TurtleToastService.DemoApp.ToastSimulation;
using TurtleToastService.Service;
using TurtleToastService.Service.ToastStyling;

namespace TurtleToastService.DemoApp;

public class MainWindowViewModel
{
    public RelayCommand ClearAllToastsCommand { get; } = new RelayCommand(TurtleToast.ClearAll);
    public RelayCommand ClearUpcomingToastsCommand { get; } = new RelayCommand(TurtleToast.ClearUpcoming);
    public RelayCommand<ToastTheme> ChangeThemeCommand { get; } = new RelayCommand<ToastTheme>(ThemeChangeSimulation.ChangeTheme);
}
