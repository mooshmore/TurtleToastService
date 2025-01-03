﻿using TurtleToastService.Service;
using TurtleToastService.Service.Core;

namespace TurtleToastService.DemoApp.ToastSimulation;

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
                TurtleToast.Confirmation("ConfirmationToast toast low priority", Priority.Low);
                break;
            case Priority.Medium:
                TurtleToast.Confirmation("ConfirmationToast toast medium priority", Priority.Medium);
                break;
            case Priority.High:
                TurtleToast.Confirmation("ConfirmationToast toast high priority", Priority.High);
                break;
        }
    }
}
