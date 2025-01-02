using TurtleToast.Service.Core;

namespace TurtleToast.DemoApp.ToastSimulation;

internal static class ConfirmationSimulation
{
    /// <summary>
    /// Displays a confirmation toast.
    /// </summary>
    internal static void ConfirmationToast(Priority toastPriority)
    {
        switch (toastPriority)
        {
            case Priority.Low:
                TurtleToastService.Default.Confirmation("ConfirmationToast toast low priority", Priority.Low);
                break;
            case Priority.Medium:
                TurtleToastService.Default.Confirmation("ConfirmationToast toast medium priority", Priority.Medium);
                break;
            case Priority.High:
                TurtleToastService.Default.Confirmation("ConfirmationToast toast high priority", Priority.High);
                break;
        }
    }
}
