using CrossUtilitesWPF.Bases;
using TurtleToastSerice.Service;
using TurtleToastService.DemoApp.ToastSimulation;

namespace TurtleToastService.DemoApp
{
    internal class MainWindowViewModel
    {
        public RelayCommand InformationToastCommand { get; } = new RelayCommand(InformationSimulation.InformationToast);
        public RelayCommand ConfirmationToastCommand { get; } = new RelayCommand(ConfirmationSimulation.ConfirmationToast);
        public RelayCommand LoadingCountCommand { get; } = new RelayCommand(LoadingSimulation.LoadingCount);
        public RelayCommand LoadingInfiniteCommand { get; } = new RelayCommand(LoadingSimulation.LoadingInfinite);
        public RelayCommand IncreaseCountOneCommand { get; } = new RelayCommand(LoadingSimulation.IncreaseCountByOne);
        public RelayCommand IncreaseCountFiveCommand { get; } = new RelayCommand(LoadingSimulation.IncreaseCountByFive);
        public RelayCommand EndLoadingCommand { get; } = new RelayCommand(LoadingSimulation.CompleteToast);
        public RelayCommand ClearAllToastsCommand { get; } = new RelayCommand(TurtleToast.ClearAll);
        public RelayCommand ClearUpcomingToastsCommand { get; } = new RelayCommand(TurtleToast.ClearUpcoming);
        public RelayCommand ChangeThemeCommand { get; } = new RelayCommand(ThemeChangeSimulation.ChangeTheme);
    }
}
