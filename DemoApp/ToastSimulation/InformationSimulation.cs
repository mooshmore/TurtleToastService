using TurtleToastService.Service;
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
                TurtleToast.Information("Information toast low priority", Priority.Low);
                break;
            case Priority.Medium:
                TurtleToast.Information("Information toast medium priority", Priority.Medium);
                break;
            case Priority.High:
                TurtleToast.Information("Information toast high priority", Priority.High);
                break;
        }
    }
}
