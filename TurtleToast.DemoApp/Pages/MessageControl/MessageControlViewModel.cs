
using CommunityToolkit.Mvvm.Input;
using TurtleToast.DemoApp.ToastSimulation;
using TurtleToast.Service.Core;

namespace TurtleToast.DemoApp.Pages.MessageControl;

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
