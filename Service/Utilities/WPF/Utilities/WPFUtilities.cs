using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TurtleToastService.Service.Utilities.WPF.Converters
{
    /// <summary>
    /// Holds various utilities for use with WPF.
    /// </summary>
    public static class WPFUtilities
    {
        /// <summary>
        /// Sets the vertical offset of the given <paramref name="grid"/>.
        /// </summary>
        public static double GetVerticalOffset(this DataGrid grid)
        {
            return FindVisualChild<ScrollViewer>(grid).VerticalOffset;
        }

        /// <summary>
        /// Sets the vertical offset of the given <paramref name="grid"/>.
        /// </summary>
        public static void SetVerticalOffset(this DataGrid grid, double offset)
        {
            // Get the scrollViewer
            ScrollViewer scrollView = FindVisualChild<ScrollViewer>(grid);
            // One row is exactly one unit of vertical offset in a dataGrid
            scrollView.ScrollToVerticalOffset(offset);
        }

        /// <summary>
        /// Expands all items of the given <paramref name="treeView"/>.
        /// </summary>
        public static void ExpandAllItems(this TreeView treeView)
        {
            foreach (var item in treeView.Items)
            {
                if (treeView.ItemContainerGenerator.ContainerFromItem(item) is TreeViewItem treeViewItem)
                {
                    treeViewItem.ExpandSubtree();
                }
            }
        }

        /// <summary>
        /// Collapses all items of the given <paramref name="treeView"/>.
        /// </summary>
        public static void CollapseAllItems(this TreeView treeView)
        {
            foreach (var item in treeView.Items)
            {
                if (treeView.ItemContainerGenerator.ContainerFromItem(item) is TreeViewItem treeViewItem)
                {
                    treeViewItem.IsExpanded = false;
                }
            }
        }

        /// <summary>
        /// Sets the keyboard focus on the first visible selected cell.
        /// </summary>
        /// <remarks>
        /// The keyboard focus won't be set if the cells aren't visible, even if they are selected.
        /// </remarks>
        public static void KeyboardFocusFirstVisibleSelectedCell(this DataGrid grid)
        {
            DataGridCell firstVisibleSelectedCell = GetFirstVisibleCell(grid.SelectedCells);
            if (firstVisibleSelectedCell != null)
                Keyboard.Focus(firstVisibleSelectedCell);
        }

        /// <summary>
        /// Returns the first visible cell from the collection, by first means the first found on the list.
        /// </summary>
        /// <returns>The first visible cell from the collection if one was found; Otherwise null.</returns>
        public static DataGridCell? GetFirstVisibleCell(IList<DataGridCellInfo> cells)
        {
            foreach (var cellInfo in cells)
            {
                // WARNING
                // This cell retrieval code is buggy and won't always return the cell content, 
                // for example if the given cell is not visible.
                // Blame microsoft.
                var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
                DataGridCell cell = (DataGridCell)cellContent?.Parent;

                if (cell == null)
                    continue;

                DataGridRow row = cell.GetRow();
                if (row.IsVisible)
                    return cell;
            }
            return null;
        }

        /// <summary>
        /// Returns the row of the <paramref name="cell"/>.
        /// </summary>
        public static DataGridRow GetRow(this DataGridCell cell) => DataGridRow.GetRowContainingElement(cell);

        /// <summary>
        /// Sets the maximum width of a column, while preserving the auto sizing to cell content functionality
        /// and allows resizing.
        /// </summary>
        public static void SetAutoSizeMaxColumnWidth(this DataGrid dataGrid, float maxWidth)
        {
            dataGrid.AutoGeneratingColumn += async (s, e) =>
            {

                // Set the maximum width for each column
                if (e.Column is DataGridBoundColumn)
                {
                    e.Column.MaxWidth = maxWidth;
                }

                // Wait for the population of the table
                // After 100 ms the ability to resize columns is unlocked

                // And yes, it isn't pretty, but this thing is only on the UI side,
                // and the only thing it does it unlocks resizing of the dataGrid.
                await Task.Delay(100);
                e.Column.Width = e.Column.ActualWidth;
                e.Column.MaxWidth = double.PositiveInfinity;
            };
        }

        /// <summary>
        /// Returns the first input, like a TextBox or a ComboBox.
        /// </summary>
        /// <remarks>
        /// This only checks if the input is a <see cref="Control"/> (with the exclusion of <see cref="ContentControl"/>),
        /// so it might catch some wrong elements. <br/>
        /// Worked well for me.
        /// </remarks>
        public static Control? FindFirstInput(DependencyObject? depObj)
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is Control control && child is not ContentControl)
                    {
                        return control;
                    }

                    Control? childItem = FindFirstInput(child);
                    if (childItem != null)
                        return childItem;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the visual child of a element.
        /// Also works for embedded elements, like a scrollViewer inside of a dataGrid.
        /// </summary>
        /// <typeparam name="T">The type of the control to look for.</typeparam>
        /// <param name="control">The control that the element is in.</param>
        /// <returns>The found visual child.</returns>
        public static T? FindVisualChild<T>(DependencyObject? control) where T : DependencyObject
        {
            if (control != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
                {
                    DependencyObject? child = VisualTreeHelper.GetChild(control, i);
                    if (child != null && child is T t)
                    {
                        return t;
                    }

                    T? childItem = FindVisualChild<T>(child);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }

        /// <summary>
        /// Selects the cells in the given dataGrid.
        /// </summary>
        /// <param name="dataGrid">The dataGrid to select cells in.</param>
        /// <param name="cellPositions">A list of cell positions; Key - rowIndex, Value - columnIndex.</param>
        public static void SelectCellsByIndexes(DataGrid dataGrid, IDictionary<int, int> cellPositions)
        {
            dataGrid.SelectedCells.Clear();

            foreach (KeyValuePair<int, int> cellIndex in cellPositions)
            {
                int rowIndex = cellIndex.Key;
                int columnIndex = cellIndex.Value;

                // Verify that row index and column index aren't out of bounds of the datagrid
                if (rowIndex < 0
                    || columnIndex < 0
                    || rowIndex >= dataGrid.Items.Count
                    || columnIndex >= dataGrid.Columns.Count)
                    continue;

                DataGridCellInfo cellInfo = new(dataGrid.Items[rowIndex], dataGrid.Columns[columnIndex]);

                dataGrid.SelectedCells.Add(cellInfo);
            }

            dataGrid.Focus();
        }
    }
}
