using TurtleToastService.Service.Service;
using System;
using System.Timers;

namespace TurtleToastService.Service.Views.Information
{
    /// <summary>
    /// A toast message used to display simple information.
    /// </summary>
    public class InformationToastViewModel : IToast, IDisposable
    {
        /// <summary>
        /// Creates a toast message used to display simple information.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public InformationToastViewModel(string message, Priority priority)
        {
            Message = message;
            Priority = priority;
        }

        /// <summary>
        /// A toast message used to display simple information.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public InformationToastViewModel(string message, string secondaryMessage, Priority priority) : this (message, priority)
        {
            SecondaryMessage = secondaryMessage;
        }

        /// <inheritdoc/>
        public string Message { get; set; }
        /// <inheritdoc/>
        public string SecondaryMessage { get; set; }
        /// <inheritdoc/>
        public Priority Priority { get; set; }
        /// <inheritdoc/>
        public EventHandler Completed { get; set; }

        private Timer _timer { get; set; }

        /// <inheritdoc/>
        public void Display()
        {
            _timer = ToastHelpers.CreateTimer(Completed, Message);
            _timer.Start();
        }

        /// <summary>
        /// Disposes any timers and subscriptions assigned to event handlers.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
