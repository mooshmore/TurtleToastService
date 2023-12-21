using TurtleToastService.Service.Core;
using Utilities.WPF.Bases;

namespace TurtleToastService.Service.ToastHost
{
    /// <summary>
    /// A viewModel which acts as a host for the toasts.
    /// </summary>
    public class ToastHostViewModel : ViewModelBase, IToastHost
    {
        /// <inheritdoc/>
        public void HostToast(IToast toast)
        {
            // Assign the new view model to the data context
            ToastContext = toast;
            RaisePropertyChanged(nameof(ToastContext));
        }

        /// <summary>
        /// The content of the button.
        /// </summary>
        public string? ButtonContent { get; set; }

        /// <summary>
        /// The data context of the toast.
        /// </summary>
        public IToast? ToastContext { get; set; }

        /// <inheritdoc/>
        public void VacateToast(IToast toast)
        {
            // Check if the toast is still the dataContext
            // (it might have been switched to a other toast in the meantime)
            // 
            // Execute the operation on the UI thread
            if (ToastContext == toast)
            {
                ToastContext = null;
                RaisePropertyChanged(nameof(ToastContext));
            }
        }
    }
}