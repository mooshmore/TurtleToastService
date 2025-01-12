using CommunityToolkit.Mvvm.Input;
using TurtleToast.DemoApp.ToastSimulation;
using TurtleToast.Service.Core;
using TurtleToast.Service.ToastStyling;

namespace TurtleToast.DemoApp;

public class MainWindowViewModel
{
    public RelayCommand ClearAllToastsCommand { get; } = new RelayCommand(TurtleToastService.Default.ClearAll);
    public RelayCommand ClearUpcomingToastsCommand { get; } = new RelayCommand(TurtleToastService.Default.ClearAllUpcoming);
    public RelayCommand<ToastTheme> ChangeThemeCommand { get; } = new RelayCommand<ToastTheme>(ThemeChangeSimulation.ChangeTheme);
}
