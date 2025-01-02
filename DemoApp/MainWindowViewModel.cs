using CommunityToolkit.Mvvm.Input;
using TurtleToastService.DemoApp.ToastSimulation;
using TurtleToastService.Service.Core;
using TurtleToastService.Service.ToastStyling;

namespace TurtleToastService.DemoApp;

public class MainWindowViewModel
{
    public RelayCommand ClearAllToastsCommand { get; } = new RelayCommand(TurtleToastService.Service.Core.TurtleToastService.Default.ClearAll);
    public RelayCommand ClearUpcomingToastsCommand { get; } = new RelayCommand(TurtleToastService.Service.Core.TurtleToastService.Default.ClearAllUpcoming);
    public RelayCommand<ToastTheme> ChangeThemeCommand { get; } = new RelayCommand<ToastTheme>(ThemeChangeSimulation.ChangeTheme);
}
