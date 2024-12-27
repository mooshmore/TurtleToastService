
using CommunityToolkit.Mvvm.Input;
using TurtleToastService.DemoApp.ToastSimulation;
using TurtleToastService.Service.Core;

namespace TurtleToastService.DemoApp.Pages.MessageControl
{
    public class MessageControlViewModel
    {
        public RelayCommand<Priority> InformationToastCommand { get; } = new RelayCommand<Priority>(InformationSimulation.InformationToast);
        public RelayCommand<Priority> ConfirmationToastCommand { get; } = new RelayCommand<Priority>(ConfirmationSimulation.ConfirmationToast);
        public RelayCommand LoadingCountCommand { get; } = new RelayCommand(LoadingSimulation.LoadingCount);
        public RelayCommand LoadingInfiniteCommand { get; } = new RelayCommand(LoadingSimulation.LoadingInfinite);
        public RelayCommand IncreaseCountOneCommand { get; } = new RelayCommand(LoadingSimulation.IncreaseCountByOne);
        public RelayCommand IncreaseCountFiveCommand { get; } = new RelayCommand(LoadingSimulation.IncreaseCountByFive);
        public RelayCommand EndLoadingCommand { get; } = new RelayCommand(LoadingSimulation.CompleteToast);
    }
}
