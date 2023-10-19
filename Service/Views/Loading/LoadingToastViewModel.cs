using TurtleToastService.Service.Service;
using System;
using System.Timers;
using Utilities.WPF.Bases;

namespace TurtleToastService.Service.Views.Loading
{
    /// <summary>
    /// A toast message sed to display a progress of an action.
    /// </summary>
    public class LoadingToastViewModel : ViewModelBase, IToast
    {
        /// <summary>
        /// Creates a toast message used to display a progress of an action.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="operationsCount">The total count of operations that will be performed.</param>
        /// <param name="progressEvent">The event which invocation will increment the progress value.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public LoadingToastViewModel(
            string message,
            string? secondaryMessage = null,
            int operationsCount = -1,
            EventHandler<EventArgs>? progressEvent = null,
            ProgressDisplayMode displayMode = ProgressDisplayMode.Percentage,
            string? succesMessage = null,
            Priority priority = Priority.Medium)
        {
            _prefixMessage = message;
            SecondaryMessage = secondaryMessage;
            Priority = priority;
            OperationsCount = operationsCount;
            _displayMode = displayMode;
            _progressEvent = progressEvent;
            _succesMessage = succesMessage;

            GenerateMessage();
            _progressEvent += IncrementProgress;
        }

        /// <inheritdoc/>
        public string Message { get; set; }
        /// <inheritdoc/>
        public string? SecondaryMessage { get; set; }
        /// <inheritdoc/>
        public Priority Priority { get; set; }
        /// <inheritdoc/>
        public EventHandler Completed { get; set; }

        /// <summary>
        /// The total count of operations to make.
        /// </summary>
        public int OperationsCount { get; set; } = -1;

        private readonly ProgressDisplayMode _displayMode;
        private int _count;
        private readonly string _prefixMessage;
        private readonly string? _succesMessage;
        private Timer _timer;
        private EventHandler<EventArgs>? _progressEvent;

        /// <summary>
        /// Increments the progress value.
        /// </summary>
        /// <param name="incrementValue">The value to increment by.</param>
        public void IncrementProgress(int incrementValue = 1)
        {
            _count += incrementValue;

            if (OperationsCount <= _count)
                FinalizeToast();
            else
                GenerateMessage();
        }

        /// <summary>
        /// Increments the progress value.
        /// </summary>
        public void IncrementProgress(object obj, EventArgs evnt) => IncrementProgress(1);

        /// <summary>
        /// Displays the succes message if one was defined and invokes the <see cref="Completed"/> event.
        /// </summary>
        private void FinalizeToast()
        {
            if (Message != null)
            {
                Message = _succesMessage;
                SecondaryMessage = "";
                RaisePropertyChanged(nameof(Message));
                RaisePropertyChanged(nameof(SecondaryMessage));

                _timer = ToastHelpers.CreateTimer(Completed, Message);
                _timer.Start();

            }
            else
                Completed.Invoke(null, null);
        }


        /// <summary>
        /// Generates the appropriate progress message based on the chosen display mode.
        /// See <see cref="ProgressDisplayMode"/> for syntax examples.
        /// </summary>
        private void GenerateMessage()
        {
            switch (_displayMode)
            {
                case ProgressDisplayMode.None:
                    Message = _prefixMessage;
                    break;
                case ProgressDisplayMode.Count:
                    Message = $"{_prefixMessage} {_count}";
                    break;
                case ProgressDisplayMode.OperationsCount:
                    Message = $"{_prefixMessage} {OperationsCount}";
                    break;
                case ProgressDisplayMode.FullCount:
                    Message = $"{_prefixMessage} {_count} of {OperationsCount}";
                    break;
                case ProgressDisplayMode.Percentage:
                    Message = $"{_prefixMessage} ({(int)((double)_count / OperationsCount * 100)}%)";
                    break;
                case ProgressDisplayMode.CountAndPercentage:
                    Message = $"{_prefixMessage} {_count} of {OperationsCount} ({(int)((double)_count / OperationsCount * 100)}%)";
                    break;
                default:
                    break;
            }

            RaisePropertyChanged(nameof(Message));
        }

        /// <inheritdoc/>
        public void Display() { }

        /// <summary>
        /// Disposes any timers and subscriptions assigned to event handlers.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
            _progressEvent -= IncrementProgress;
        }
    }
}
