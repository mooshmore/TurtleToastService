using System;
using TurtleToastService.Service.Core;
using TurtleToastService.Service.ToastStyling;
using TurtleToastService.Service.Views.Confirmation;
using TurtleToastService.Service.Views.Information;
using TurtleToastService.Service.Views.Loading;

namespace TurtleToastSerice.Service
{
    /// <summary>
    /// A collection of methods for use with IToastService.
    /// </summary>
    public static class TurtleToast
    {
        private static readonly IToastService _service = new TurtleToastService.Service.Core.TurtleToastService();

        #region Service commands

        /// <summary>
        /// Puts the given toast in the service queue.
        /// </summary>
        public static void EnqueueToast(IToast toast) => _service.EnqueueToast(toast);

        /// <summary>
        /// Clears all toasts besides the one that is currently active.
        /// </summary>
        public static void ClearUpcoming() => _service.ClearAllUpcoming();

        /// <summary>
        /// Clears all toats.
        /// </summary>
        public static void ClearAll() => _service.ClearAll();

        /// <summary>
        /// Changes the used theme of the service.
        /// </summary>
        /// <param name="theme">The theme to change to. See <see cref="ToastTheme"/> for the list of avaialable themes.</param>
        public static void ChangeTheme(ToastTheme theme) => ThemeManager.ChangeTheme(theme);

        /// <summary>
        /// The theme currently used by the service.
        /// </summary>
        public static ToastTheme CurrentTheme => ThemeManager.ActiveTheme;

        #endregion

        #region Information

        /// <summary>
        /// Displays a toast message which will dissapear after a certain amount of time.
        /// </summary>
        /// <remarks>
        /// The display time is calulcated based on the message length.
        /// </remarks>
        /// <param name="message">The message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Information(string message, Priority priority = Priority.Low)
        {
            _service.EnqueueToast(new InformationToastViewModel(message, priority));
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
        public static void Information(string message, string secondaryMessage, Priority priority = Priority.Low)
        {
            _service.EnqueueToast(new InformationToastViewModel(message, secondaryMessage, priority));
        }

        #endregion

        #region Confirmation

        /// <summary>
        /// Displays a toast message which requires user confirmation.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Confirmation(string message, Priority priority = Priority.Medium)
        {
            _service.EnqueueToast(new ConfirmationToastViewModel(message, priority));
        }

        /// <summary>
        /// Displays a toast message which requires user confirmation.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public static void Confirmation(string message, string secondaryMessage, Priority priority = Priority.Medium)
        {
            _service.EnqueueToast(new ConfirmationToastViewModel(message, secondaryMessage, priority));
        }

        #endregion

        #region Loading

        /// <summary>
        /// Displays toast message which shows a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="totalOperationsCount">The total count of operations that will be performed.</param>
        /// <param name="progressEvent">The event which invocation will increment the progress value.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. Set to null if no succes message should be displayed.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        /// <returns>The completed event that can be used to manually end the message.</returns>
        public static EventHandler Loading(string message, int totalOperationsCount, ref EventHandler progressEvent, ProgressDisplayMode displayMode = ProgressDisplayMode.None, string succesMessage = "Done!", Priority priority = Priority.Medium)
        {
            var toast = new LoadingToastViewModel(
                   message: message,
                   totalOperationsCount: totalOperationsCount,
                   progressEvent: progressEvent,
                   displayMode: displayMode,
                   succesMessage: succesMessage,
                   priority: priority
                   );

            new LoadingToastEventsHandler(toast, ref progressEvent);

            _service.EnqueueToast(toast);

            return toast.Completed;
        }

        /// <summary>
        /// Displays toast message which shows a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="progressEvent">The event which invocation will increment the progress value.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. Set to null if no succes message should be displayed.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        /// <returns>The completed event that can be used to manually end the message.</returns>
        public static EventHandler Loading(string message, string secondaryMessage, ref EventHandler progressEvent, ProgressDisplayMode displayMode = ProgressDisplayMode.None, string succesMessage = "Done!", Priority priority = Priority.Medium)
        {
            var toast = new LoadingToastViewModel(
                   message: message,
                   secondaryMessage: secondaryMessage,
                   progressEvent: progressEvent,
                   displayMode: displayMode,
                   succesMessage: succesMessage,
                   priority: priority
                   );

            new LoadingToastEventsHandler(toast, ref progressEvent);

            _service.EnqueueToast(toast);

            return toast.Completed;
        }

        /// <summary>
        /// Displays toast message which shows a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="totalOperationsCount">The total count of operations that will be performed.</param>
        /// <param name="progressEvent">The event which invocation will increment the progress value.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. Set to null if no succes message should be displayed.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        /// <returns>The completed event that can be used to manually end the message.</returns>
        public static EventHandler Loading(string message, string secondaryMessage, int totalOperationsCount, ref EventHandler progressEvent, ProgressDisplayMode displayMode = ProgressDisplayMode.None, string succesMessage = "Done!", Priority priority = Priority.Medium)
        {
            var toast = new LoadingToastViewModel(
                   message: message,
                   secondaryMessage: secondaryMessage,
                   totalOperationsCount: totalOperationsCount,
                   progressEvent: progressEvent,
                   displayMode: displayMode,
                   succesMessage: succesMessage,
                   priority: priority
                   );

            new LoadingToastEventsHandler(toast, ref progressEvent);

            _service.EnqueueToast(toast);

            return toast.Completed;
        }

        #endregion
    }
}
