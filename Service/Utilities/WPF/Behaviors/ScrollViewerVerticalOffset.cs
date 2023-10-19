using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace Utilities.WPF.Behaviors
{
    /// <summary>
    /// A WPF behaviour that allows binding to a vertical offset of a scrollviewer.
    /// </summary>
    public class ScrollViewerVerticalOffset : Behavior<ScrollViewer>
    {
        /// <summary>
        /// A dependency property for the vertical offset.
        /// </summary>
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register("VerticalOffset", typeof(double), typeof(ScrollViewerVerticalOffset), new PropertyMetadata(0.0, OnVerticalOffsetChanged));

        /// <summary>
        /// Gets or sets the vertical offset of a scrollViewer.
        /// </summary>
        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        /// <summary>
        /// A method that is run when attached to a element.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ScrollChanged += OnScrollChanged;
        }

        /// <summary>
        /// A method that is run when detached from a element.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.ScrollChanged -= OnScrollChanged;
        }

        private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (sender is ScrollViewer scrollViewer)
                VerticalOffset = scrollViewer.VerticalOffset;
        }

        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as ScrollViewerVerticalOffset;
            behavior.AssociatedObject?.ScrollToVerticalOffset((double)e.NewValue);
        }
    }
}
