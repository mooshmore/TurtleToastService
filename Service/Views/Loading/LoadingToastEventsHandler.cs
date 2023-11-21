using System;

namespace TurtleToastService.Service.Views.Loading
{
    /// <summary>
    /// A helper class used by the <see cref="TurtleToastSerice.Service.TurtleToast"/> 
    /// with event subscriptions for the <see cref="LoadingToastViewModel"/>.
    /// </summary>
    public class LoadingToastEventsHandler
    {
        private LoadingToastViewModel _toast;
        private EventHandler _externalHandler;

        public LoadingToastEventsHandler(LoadingToastViewModel toast, ref EventHandler externalHandler)
        {
            _toast = toast;
            _externalHandler = externalHandler;

            externalHandler += IncrementProgress;
            // Subscribe to the Completed event
            _toast.Completed += UnsubscribeEvents;
        }

        void IncrementProgress(object obj, EventArgs args)
        {
            _toast.IncrementProgress();
        }

        private void UnsubscribeEvents(object sender, EventArgs e)
        {
            // Todo: this unsubscribing is actually not unsubscribing the external handler passed by the constructor.
            // This can be seen by assigning the IncrementProgress to the _externalHandler straight away on line 19,
            // instead of the passed event.
            _externalHandler -= IncrementProgress;

            // Unsubscribe the external event handler
            _toast.Completed -= _externalHandler;
        }
    }
}
