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

            _externalHandler += IncrementProgress;
            // Subscribe to the Completed event
            _toast.Completed += UnsubscribeEvents;
        }

        void IncrementProgress(object obj, EventArgs args)
        {
            _toast.IncrementProgress();
        }

        private void UnsubscribeEvents(object sender, EventArgs e)
        {
            _externalHandler -= IncrementProgress;

            // Unsubscribe the external event handler
            _toast.Completed -= _externalHandler;
        }
    }
}
