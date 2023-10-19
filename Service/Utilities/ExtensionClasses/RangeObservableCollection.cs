using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TurtleToastService.Service.Utilities.ExtensionClasses
{
    /// <summary>
    /// A observable collection with a added functionality of AddRange method, 
    /// which allows to suppres the triggering of OnCollectionChanged event while adding multiple items
    /// after every item add.
    /// The OnCollectionChanged event is triggered only once, after the whole range is added.
    /// </summary>
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _suppressNotification = false;

        /// <summary>
        /// A event that is raised when the collection changes.
        /// </summary>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
                base.OnCollectionChanged(e);
        }

        /// <summary>
        /// Adds a range to the collection.
        /// This method triggers OnCollectionChanged event only once, after the whole collection 
        /// is added.
        /// </summary>
        /// <param name="collection">The collection do add.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            _suppressNotification = true;

            foreach (T item in collection)
            {
                Add(item);
            }
            _suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
