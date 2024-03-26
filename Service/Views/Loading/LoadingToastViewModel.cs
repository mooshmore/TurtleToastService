using System;
using System.Timers;
using CrossUtilites.WPF.Bases;
using TurtleToastService.Service.Core;
using CrossUtilites.WPF.Bases;

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
        /// <param name="totalOperationsCount">The total count of operations that will be performed.</param>
        /// <param name="progressEvent">The event which invocation will increment the progress value.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. If not defined, the succes message won't display at all.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public LoadingToastViewModel(
            string message,
            string? secondaryMessage = null,
            int totalOperationsCount = -1,
            EventHandler? progressEvent = null,
            ProgressDisplayMode displayMode = ProgressDisplayMode.Percentage,
            string? succesMessage = null,
            Priority priority = Priority.Medium)
        {
            _prefixMessage = message;
            SecondaryMessage = secondaryMessage;
            Priority = priority;
            TotalOperationsCount = totalOperationsCount;
            _displayMode = displayMode;
            _progressEvent = progressEvent;
            _succesMessage = succesMessage;

            GenerateMessage();
            _progressEvent += IncrementProgress;
        }

        private string _message;

        /// <inheritdoc/>
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }

        private string? _secondaryMessage;

        /// <inheritdoc/>
        public string? SecondaryMessage
        {
            get => _secondaryMessage;
            set
            {
                _secondaryMessage = value;
                RaisePropertyChanged();
            }
        }
        /// <inheritdoc/>
        public Priority Priority { get; set; }
        /// <inheritdoc/>
        public EventHandler? Completed { get; set; }

        /// <summary>
        /// The total count of operations to make.
        /// </summary>
        public int TotalOperationsCount { get; set; } = -1;

        private readonly ProgressDisplayMode _displayMode;
        private int _count;
        private readonly string _prefixMessage;
        private readonly string? _succesMessage;
        private Timer _timer;
        private EventHandler? _progressEvent;

        private bool _displayLoadingIcon = true;

        /// <summary>
        /// Whether the loading icon should be displayed or not.
        /// </summary>
        public bool DisplayLoadingIcon
        {
            get => _displayLoadingIcon;
            set
            {
                _displayLoadingIcon = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Increments the progress value.
        /// </summary>
        /// <param name="incrementValue">The value to increment by.</param>
        public void IncrementProgress(int incrementValue = 1)
        {
            _count += incrementValue;

            if (TotalOperationsCount > _count || TotalOperationsCount == -1)
                GenerateMessage();
            else
                FinalizeToast();
        }

        /// <summary>
        /// Increments the progress value.
        /// Todo: Add a ability to increment the progress by a specific value using the argument
        /// </summary>
        public void IncrementProgress(object obj, EventArgs args) => IncrementProgress(1);

        /// <summary>
        /// Displays the succes message if one was defined and invokes the <see cref="Completed"/> event.
        /// </summary>
        private void FinalizeToast()
        {
            if (_succesMessage != null)
            {
                DisplayLoadingIcon = false;
                Message = _succesMessage;
                SecondaryMessage = null;

                _timer = ToastHelpers.CreateTimer(Completed, Message);
                _timer.Start();
            }
            else
                Completed?.Invoke(null, null);
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
                    Message = $"{_prefixMessage} {TotalOperationsCount}";
                    break;
                case ProgressDisplayMode.FullCount:
                    Message = $"{_prefixMessage} {_count} of {TotalOperationsCount}";
                    break;
                case ProgressDisplayMode.Percentage:
                    Message = $"{_prefixMessage} ({(int)((double)_count / TotalOperationsCount * 100)}%)";
                    break;
                case ProgressDisplayMode.CountAndPercentage:
                    Message = $"{_prefixMessage} {_count} of {TotalOperationsCount} ({(int)((double)_count / TotalOperationsCount * 100)}%)";
                    break;
                default:
                    break;
            }
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
