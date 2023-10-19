using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Utilities.WPF.Bases
{
    /// <summary>
    /// A asynchronous relay command for XAML Binding.
    /// </summary>
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<object, Task> _parameterExecute;
        private readonly Func<Task> _execute;
        private readonly Func<object, bool> _canExecute;

        private long isExecuting;

        /// <summary>
        /// A constructor with a single parameter.
        /// </summary>
        public AsyncRelayCommand(Func<object, Task> parameterExecute, Func<object, bool>? canExecute = null)
        {
            this._parameterExecute = parameterExecute;
            this._canExecute = canExecute ?? (o => true);
        }

        /// <summary>
        /// A constructor with a single parameter.
        /// </summary>
        public AsyncRelayCommand(Func<Task> execute, Func<object, bool>? canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute ?? (o => true);
        }

        /// <summary>
        /// A event that is triggered when a CanExecute state changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Raises a event which signalizes that CanExecute state changed.
        /// </summary>
        public static void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Checks if the command can execute.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (Interlocked.Read(ref isExecuting) != 0)
                return false;

            return _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public async void Execute(object parameter)
        {
            Interlocked.Exchange(ref isExecuting, 1);
            RaiseCanExecuteChanged();

            try
            {
                if (_execute != null)
                    await _execute();
                if (_parameterExecute != null)
                    await _parameterExecute(parameter);
            }
            finally
            {
                Interlocked.Exchange(ref isExecuting, 0);
                RaiseCanExecuteChanged();
            }
        }
    }
}
