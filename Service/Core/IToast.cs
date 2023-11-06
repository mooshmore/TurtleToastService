using System;

namespace TurtleToastService.Service.Core
{
    /// <summary>
    /// The interaface for the toast message.
    /// </summary>
    public interface IToast : IDisposable
    {
        /// <summary>
        /// The message of the toast.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The seconday message of the toast .
        /// </summary>
        string? SecondaryMessage { get; set; }

        /// <summary>
        /// The priority of the toast.
        /// </summary>
        Priority Priority { get; set; }

        /// <summary>
        /// A event that is raised when the toast completes it's display.
        /// </summary>
        EventHandler? Completed { get; set; }

        /// <summary>
        /// Starts the timers or other processes on the toast message, if there are any.
        /// </summary>
        void Display();
    }
}
