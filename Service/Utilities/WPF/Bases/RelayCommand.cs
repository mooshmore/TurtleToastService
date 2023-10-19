using System;
using System.Windows.Input;

namespace Utilities.WPF.Bases
{
    /// <summary>
    /// A relay command for XAML Binding.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The basic constructor for the relay command.
        /// </summary>
        public RelayCommand(Action callback, Func<bool>? canExecute = null)
        {
            _callback = callback;
            _canExecute = canExecute ?? (() => true);
        }

        /// <summary>
        /// A constructor for a relay command with a single parameter.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> callback, Func<bool>? canExecute = null)
        {
            _parameterCallback = callback;
            _canExecute = canExecute ?? (() => true);
        }

        private readonly Action _callback;
        private readonly Action<object> _parameterCallback;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// An event that is triggered when CanExecute state of the command changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Checks if the command can execute.
        /// </summary>
        public bool CanExecute(object parameter) => _canExecute();

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute(object parameter)
        {
            _parameterCallback?.Invoke(parameter);
            _callback?.Invoke();
        }
    }
}
