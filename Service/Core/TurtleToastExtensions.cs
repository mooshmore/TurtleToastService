using TurtleToastService.Service.Views.Confirmation;
using TurtleToastService.Service.Views.Information;
using TurtleToastService.Service.Views.Loading;

namespace TurtleToastService.Service.Core
{
    /// <summary>
    /// A collection of methods for use with IToastService.
    /// </summary>
    public static class TurtleToastExtensions
    {
        #region Information

        /// <summary>
        /// Displays a toast message which will dissapear after a certain amount of time.
        /// </summary>
        /// <remarks>
        /// The display time is calulcated based on the message length.
        /// </remarks>
        /// <param name="message">The message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Information(this ITurtleToastService toastService, string message, Priority priority = Priority.Low)
        {
            toastService.EnqueueToast(new InformationToastViewModel(message, priority));
        }

        /// <summary>
        /// Displays a toast message which will dissapear after a certain amount of time.
        /// </summary>
        /// <remarks>
        /// The display time is calulcated based on the message length.
        /// </remarks>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Information(this ITurtleToastService toastService, string message, string secondaryMessage, Priority priority = Priority.Low)
        {
            toastService.EnqueueToast(new InformationToastViewModel(message, secondaryMessage, priority));
        }

        #endregion

        #region Confirmation

        /// <summary>
        /// Displays a toast message which requires user confirmation.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Confirmation(this ITurtleToastService toastService, string message, Priority priority = Priority.Medium)
        {
            toastService.EnqueueToast(new ConfirmationToastViewModel(message, priority));
        }

        /// <summary>
        /// Displays a toast message which requires user confirmation.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Confirmation(this ITurtleToastService toastService, string message, string secondaryMessage, Priority priority = Priority.Medium)
        {
            toastService.EnqueueToast(new ConfirmationToastViewModel(message, secondaryMessage, priority));
        }

        #endregion

        #region Loading

        /// <summary>
        /// Displays toast message which shows a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="totalOperationsCount">The total count of operations that will be performed.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. Set to null if no succes message should be displayed.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        /// <returns>The completed event that can be used to manually end the message.</returns>
        public static ILoadingToast Loading(this ITurtleToastService toastService, string message, int totalOperationsCount, ProgressDisplayMode displayMode = ProgressDisplayMode.None, string succesMessage = "Done!", Priority priority = Priority.Medium)
        {
            var toast = new LoadingToastViewModel(
                   message: message,
                   totalOperationsCount: totalOperationsCount,
                   displayMode: displayMode,
                   succesMessage: succesMessage,
                   priority: priority
                   );

            toastService.EnqueueToast(toast);

            return toast;
        }

        /// <summary>
        /// Displays toast message which shows a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. Set to null if no succes message should be displayed.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        /// <returns>The completed event that can be used to manually end the message.</returns>
        public static ILoadingToast Loading(this ITurtleToastService toastService, string message, string secondaryMessage, ProgressDisplayMode displayMode = ProgressDisplayMode.None, string succesMessage = "Done!", Priority priority = Priority.Medium)
        {
            var toast = new LoadingToastViewModel(
                   message: message,
                   secondaryMessage: secondaryMessage,
                   displayMode: displayMode,
                   succesMessage: succesMessage,
                   priority: priority
                   );

            toastService.EnqueueToast(toast);

            return toast;
        }

        /// <summary>
        /// Displays toast message which shows a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="totalOperationsCount">The total count of operations that will be performed.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. Set to null if no succes message should be displayed.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        /// <returns>The completed event that can be used to manually end the message.</returns>
        public static ILoadingToast Loading(this ITurtleToastService toastService, string message, string secondaryMessage, int totalOperationsCount, ProgressDisplayMode displayMode = ProgressDisplayMode.None, string succesMessage = "Done!", Priority priority = Priority.Medium)
        {
            var toast = new LoadingToastViewModel(
                   message: message,
                   secondaryMessage: secondaryMessage,
                   totalOperationsCount: totalOperationsCount,
                   displayMode: displayMode,
                   succesMessage: succesMessage,
                   priority: priority
                   );

            toastService.EnqueueToast(toast);

            return toast;
        }

        #endregion
    }
}
