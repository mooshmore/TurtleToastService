﻿using TurtleToastService.Service;
using TurtleToastService.Service.Core;

namespace TurtleToastService.DemoApp.ToastSimulation
{
    internal class ConfirmationSimulation
    {
        /// <summary>
        /// Displays a confirmation toast.
        /// </summary>
        /// <param name="toastPriority">The <see cref="Priority"/> of the toast.</param>
        internal static void ConfirmationToast(object toastPriority)
        {
            switch ((Priority)toastPriority)
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
}
