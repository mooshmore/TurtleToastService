using TurtleToastService.Service.Core;

namespace TurtleToastService.DemoApp.ToastSimulation;

internal static class InformationSimulation
{
    /// <summary>
    /// Displays a information toast.
    /// </summary>
    internal static void InformationToast(Priority toastPriority)
    {
        switch (toastPriority)
        {
            case Priority.Low:
                TurtleToastService.Service.Core.TurtleToastService.Default.Information("Information toast low priority", Priority.Low);
                break;
            case Priority.Medium:
                TurtleToastService.Service.Core.TurtleToastService.Default.Information("Information toast medium priority", Priority.Medium);
                break;
            case Priority.High:
                TurtleToastService.Service.Core.TurtleToastService.Default.Information("Information toast high priority", Priority.High);
                break;
        }
    }
}
