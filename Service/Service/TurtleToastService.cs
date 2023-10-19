using TurtleToastService.Service.ToastHost;
using System;
using System.Collections.Generic;
using TurtleToastService.Service.Utilities.WPF.Converters;

namespace TurtleToastService.Service.Service
{
    /// <summary>
    /// A service implementation for displaying toast messages.
    /// Requires the <see cref="ToastHostView"/> control to be placed in a window where the messages should appear.
    /// </summary>
    public class TurtleToastService : IToastService
    {
        public TurtleToastService()
        {
            new DataTemplateManager().LoadDataTemplatesByConvention();
        }

        /// <summary>
        /// The queue containing the toast messages.
        /// </summary>
        private Queue<IToast> _toastQueue = new Queue<IToast>();

        /// <summary>
        /// The viewModel responsible for hosting the toast messages.
        /// </summary>
        public static IToastHost ToastHost { get; private set; } = new ToastHostViewModel();

        /// <summary>
        /// Puts the given toast into the queue.
        /// </summary>
        public void EnqueueToast(IToast toast)
        {
            if (_toastQueue.Count != 0)
            {
                Priority currentToastPriority = _toastQueue.Peek().Priority;

                // Priority is lower than current toast - don't display the toast at all
                if (toast.Priority < currentToastPriority)
                {
                    return;
                }
                // Priority is higher than current toast - clear queue and display the toast instantly
                else if (toast.Priority > currentToastPriority)
                {
                    ClearAll();
                }
                // Put the toast in the queue without doing anything if the toasts priority is the same as the current toasts priority.
            }

            _toastQueue.Enqueue(toast);

            // If the added toast is the only toast in the queue, 
            // start it straight away
            if (_toastQueue.Count == 1)
                DisplayNextToast();
        }

        /// <summary>
        /// Displays the next toast in the queue.
        /// </summary>
        private void DisplayNextToast()
        {
            if (_toastQueue.Count != 0)
            {
                var toast = _toastQueue.Peek();
                ToastHost.HostToast(toast);
                toast.Completed += OnToastCompleted;
                toast.Display();
            }
        }

        /// <summary>
        /// Removes the current toast and starts the next one.
        /// </summary>
        private void OnToastCompleted(object sender, EventArgs e)
        {
            var toast = _toastQueue.Dequeue();
            toast.Completed -= OnToastCompleted;
            ToastHost.VacateToast(toast);
            DisplayNextToast();
        }

        /// <summary>
        /// Clears all toasts besides the one that is currently active.
        /// </summary>
        public void ClearAllUpcoming()
        {
            var toast = _toastQueue.Dequeue();
            _toastQueue.Clear();
            _toastQueue.Enqueue(toast);
        }

        /// <summary>
        /// Clears all toats, including the one currently displayed.
        /// </summary>
        public void ClearAll()
        {
            if (_toastQueue.Count != 0)
            {
                // Dispose the current toast, as it probably has existing assigned events
                var toast = _toastQueue.Dequeue();
                ToastHost.VacateToast(toast);
                toast.Completed -= OnToastCompleted;
                toast.Dispose();

                _toastQueue.Clear();
            }
        }
    }
}
