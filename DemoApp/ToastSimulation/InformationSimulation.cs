using TurtleToast.Service.Core;

namespace TurtleToast.DemoApp.ToastSimulation;

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
                TurtleToastService.Default.Information("Information toast low priority", Priority.Low);
                break;
            case Priority.Medium:
                TurtleToastService.Default.Information("Information toast medium priority", Priority.Medium);
                break;
            case Priority.High:
                TurtleToastService.Default.Information("Information toast high priority", Priority.High);
                break;
        }
    }
}
