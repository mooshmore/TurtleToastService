using System;
using TurtleToastService.Service.Core;
using CrossUtilitesWPF.Bases;

namespace TurtleToastService.Service.Views.Confirmation
{
    /// <summary>
    /// A toast message used to display information which requires user confirmation.
    /// </summary>
    public class ConfirmationToastViewModel : IToast
    {
        /// <summary>
        /// Creates a toast message used to display simple information which requires user confirmation.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public ConfirmationToastViewModel(string message, Priority priority)
        {
            Message = message;
            Priority = priority;
            AcceptToastCommand = new RelayCommand(() => Completed.Invoke(null, null));
        }

        /// <summary>
        /// Creates a toast message used to display simple information which requires user confirmation.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public ConfirmationToastViewModel(string message, string secondaryMessage, Priority priority) : this(message, priority)
        {
            SecondaryMessage = secondaryMessage;
        }

        /// <inheritdoc/>
        public string? Message { get; set; }
        /// <inheritdoc/>
        public string? SecondaryMessage { get; set; }
        /// <inheritdoc/>
        public Priority Priority { get; set; }
        /// <inheritdoc/>
        public EventHandler Completed { get; set; }

        /// <summary>
        /// A command that is triggered when the user confirms the message.
        /// </summary>
        public RelayCommand AcceptToastCommand { get; }

        /// <inheritdoc/>
        public void Display() { }

        /// <summary>
        /// Disposes any timers and subscriptions assigned to event handlers.
        /// </summary>
        public void Dispose() { }
    }
}
