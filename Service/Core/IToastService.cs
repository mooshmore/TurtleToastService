namespace TurtleToastService.Service.Core
{
    /// <summary>
    /// A interface for the <see cref="TurtleToastService"/> service.
    /// </summary>
    public interface IToastService
    {
        /// <summary>
        /// Puts the given toast into the queue.
        /// </summary>
        void EnqueueToast(IToast toast);

        /// <summary>
        /// Clears all toasts besides the one that is currently active.
        /// </summary>
        void ClearAllUpcoming();

        /// <summary>
        /// Clears all toats.
        /// </summary>
        void ClearAll();
    }
}