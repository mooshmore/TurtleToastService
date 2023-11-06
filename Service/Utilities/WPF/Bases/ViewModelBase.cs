using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Utilities.WPF.Bases
{
    /// <summary>
    /// A base for view models.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// A event that can be raised on a property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises a PropertyChanged event on a property.
        /// </summary>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the proeprty of a value.
        /// </summary>
        protected bool SetProperty<T>(ref T backingStore, T value,
    [CallerMemberName] string propertyName = "",
    Action? onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
