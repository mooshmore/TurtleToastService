using CrossUtilitesWPF.Bases;
using TurtleToastService.DemoApp.ToastSimulation;
using TurtleToastService.Service;

namespace TurtleToastService.DemoApp
{
    public class MainWindowViewModel
    {
        public RelayCommand ClearAllToastsCommand { get; } = new RelayCommand(TurtleToast.ClearAll);
        public RelayCommand ClearUpcomingToastsCommand { get; } = new RelayCommand(TurtleToast.ClearUpcoming);
        public RelayCommand ChangeThemeCommand { get; } = new RelayCommand(ThemeChangeSimulation.ChangeTheme);
    }
}
