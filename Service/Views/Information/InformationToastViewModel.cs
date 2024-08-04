using System;
using System.Timers;
using TurtleToastService.Service.Core;

namespace TurtleToastService.Service.Views.Information
{
    /// <summary>
    /// A toast message used to display simple information.
    /// </summary>
    /// <remarks>
    /// Creates a toast message used to display simple information.
    /// </remarks>
    /// <param name="message">The message to display.</param>
    /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
    public class InformationToastViewModel(string message, Priority priority) : IToast, IDisposable
    {
        /// <summary>
        /// A toast message used to display simple information.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public InformationToastViewModel(string message, string secondaryMessage, Priority priority) : this(message, priority)
        {
            SecondaryMessage = secondaryMessage;
        }

        /// <inheritdoc/>
        public string Message { get; set; } = message;
        /// <inheritdoc/>
        public string SecondaryMessage { get; set; }
        /// <inheritdoc/>
        public Priority Priority { get; set; } = priority;
        /// <inheritdoc/>
        public EventHandler Completed { get; set; }

        private Timer _timer { get; set; }

        /// <inheritdoc/>
        public void Display()
        {
            _timer = ToastHelpers.CreateTimer(Completed, Message);
            _timer.Start();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _timer?.Dispose();
                }

                disposed = true;
            }
        }
    }
}
