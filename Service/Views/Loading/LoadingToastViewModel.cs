using CrossUtilitesWPF.Bases;
using System;
using System.Timers;
using TurtleToastService.Service.Core;

namespace TurtleToastService.Service.Views.Loading
{
    /// <summary>
    /// A toast message used to display a progress of an action.
    /// </summary>
    public class LoadingToastViewModel : ViewModelBase, ILoadingToast, IToast
    {
        /// <summary>
        /// Creates a toast message used to display a progress of an action.
        /// </summary>
        /// <remarks>
        /// Remember to correctly unsubscribe using <see cref="Completed"/> when attaching to IncrementProgress method.
        /// </remarks>
        /// <param name="message">The message to display.</param>
        /// <param name="secondaryMessage">The secondary message to display.</param>
        /// <param name="totalOperationsCount">The total count of operations that will be performed.</param>
        /// <param name="displayMode">The format in which the progress will be displayed. See <see cref="ProgressDisplayMode"/> for more information.</param>
        /// <param name="succesMessage">The message that will be displayed after the loading process ends. If not defined, the succes message won't display at all.</param>
        /// <param name="priority">The priority of the message. See <see cref="Priority"/> for more information.</param>
        public LoadingToastViewModel(
            string message,
            string? secondaryMessage = null,
            int totalOperationsCount = -1,
            ProgressDisplayMode displayMode = ProgressDisplayMode.Percentage,
            string? succesMessage = null,
            Priority priority = Priority.Medium)
        {
            _prefixMessage = message;
            SecondaryMessage = secondaryMessage;
            Priority = priority;
            TotalOperationsCount = totalOperationsCount;
            _displayMode = displayMode;
            _succesMessage = succesMessage;

            GenerateMessage();
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

        private bool _displayLoadingIcon = true;

        private bool _loadingFinalized = false;

        /// <summary>
        /// Whether the toast is being displayed or not.
        /// </summary>
        private bool _isDisplaying;

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

        /// <inheritdoc/>
        public void IncrementProgress(int incrementValue = 1)
        {
            if (!_isDisplaying)
                return;

            _count += incrementValue;

            if (TotalOperationsCount > _count || TotalOperationsCount == -1)
                GenerateMessage();
            else
                FinishToast();
        }

        /// <inheritdoc/>
        public void IncrementProgress(object sender, EventArgs args) => IncrementProgress(1);

        /// <inheritdoc/>
        public void IncrementProgress(object sender, int incrementValue) => IncrementProgress(incrementValue);

        /// <inheritdoc/>
        public void FinishToast(bool displaySuccesMessage = true)
        {
            if (!_isDisplaying)
                return;
            else if (_succesMessage != null && displaySuccesMessage)
                DisplaySuccesMessage();
            else
                Completed.Invoke(null, null);

            _isDisplaying = false;
        }

        /// <inheritdoc/>
        public void FinishToast(object sender, EventArgs args) => FinishToast(true);

        /// <inheritdoc/>
        public void FinishToast(object sender, bool displaySuccesMessage) => FinishToast(displaySuccesMessage);

        private void DisplaySuccesMessage()
        {
            DisplayLoadingIcon = false;
            Message = _succesMessage;
            SecondaryMessage = null;

            _timer = ToastHelpers.CreateTimer(Completed, Message);
            _timer.Start();
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
        public void Display() 
        { 
            _isDisplaying = true;
        }

        /// <summary>
        /// Disposes any timers and subscriptions assigned to event handlers.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
