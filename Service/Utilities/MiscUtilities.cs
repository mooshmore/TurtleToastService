using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TurtleToastService.Service.Utilities
{
    /// <summary>
    /// A class for all types of methods that are too small to have their own class so they are all thrown in here.
    /// </summary>
    public static class MiscUtilities
    {
        /// <summary>
        /// Opens the folder where the file is contained, and selects it.
        /// </summary>
        /// <remarks>
        /// If the given <paramref name="filePath"/> is invalid, or the file does not exist nothing will happen.
        /// </remarks>
        /// <param name="filePath">The full path to the file.</param>
        public static void OpenContainingFolder(this string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                Process.Start("explorer.exe", $"/select,\"{filePath}\"");
        }

        /// <summary>
        /// Pads the numbers to the left.
        /// </summary>
        /// <remarks>
        /// Used mainly for alphanumeric sorting.
        /// </remarks>
        internal static string AlphanumericSortPad(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }

        /// <summary>
        /// Duplicates all the values in the dictionary with the given prefix added to the each item key.
        /// </summary>
        /// <param name="dictionary">The dictionary to duplicate the values of.</param>
        /// <param name="prefix">The prefix to add to the each item key.</param>
        /// <param name="preserveOriginalItems">Whether to preserve the original items, or only leave the new items with the prefix.</param>
        /// <returns>The new dictionary with the duplicated items.</returns>
        public static Dictionary<string, double> DuplicateItemsWithPrefix(this Dictionary<string, double> dictionary, string prefix, bool preserveOriginalItems = true)
        {
            Dictionary<string, double> duplicatedDictionary = new();

            foreach (var item in dictionary)
            {
                if (preserveOriginalItems)
                    duplicatedDictionary.Add(item.Key, item.Value);

                duplicatedDictionary.Add(prefix + item.Key, item.Value);
            }

            return duplicatedDictionary;
        }

        /// <summary>
        /// Removes the row if it doesn't have a value in the column <paramref name="columnIndex"/>.
        /// </summary>
        /// <param name="dataTable">The dataTable to remove the rows from.</param>
        /// <param name="columnIndex">The index of the column to search for the values in.</param>
        /// <returns>The modified dataTable.</returns>
        public static DataTable? RemoveRowsWithoutValue(this DataTable dataTable, int columnIndex)
        {
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                string? zeroCellValue = dataTable.Rows[i][columnIndex]?.ToString();
                if (!string.IsNullOrEmpty(zeroCellValue))
                {
                    dataTable.Rows.RemoveAt(i);
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Converts the rows of the two selected columns into a dictionary.
        /// </summary>
        /// <remarks>
        /// This method assumes that the provided data will bo valid, e.g. there won't be duplicate keys or null keys.
        /// </remarks>
        /// <typeparam name="KeyType">The type of the key value.</typeparam>
        /// <typeparam name="ValueType">The type of the value.</typeparam>
        /// <param name="dataTable">The dataTable to take the data from.</param>
        /// <param name="keyColumnIndex">The index of the column where the dictionary keys should be sourced from.</param>
        /// <param name="valueColumnIndex">The index of the column where the dictionary values should be sourced from.</param>
        /// <returns>The two dataTable columns converted to a dictionary.</returns>
        public static Dictionary<KeyType, ValueType> ToDictionary<KeyType, ValueType>(this DataTable dataTable, int keyColumnIndex, int valueColumnIndex)
        {
            Dictionary<KeyType, ValueType> dictionary = new();

            foreach (DataRow row in dataTable.Rows)
            {
                KeyType? key = row[keyColumnIndex] != null ? (KeyType)row[keyColumnIndex] : default;
                ValueType? value = row[valueColumnIndex] != null ? (ValueType)row[valueColumnIndex] : default;

                dictionary.Add(key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// "Visually" converts the collection to a dataTable - the method puts in every item  in a separate row,
        /// and inserts <typeparamref name="T"/> public properties into separate cells using reflection.
        /// </summary>
        public static DataTable? ToDataTable<T>(this IEnumerable<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (var item in items)
            {
                var values = new object[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        /// <summary>
        /// Reverses the order of rows in the given dataTable.
        /// </summary>
        public static DataTable? Reverse(this DataTable dataTable)
        {
            DataTable reversedDt = dataTable.Clone();
            for (var row = dataTable.Rows.Count - 1; row >= 0; row--)
                reversedDt.ImportRow(dataTable.Rows[row]);

            return reversedDt;
        }

        /// <summary>
        /// Displays a file dialog that allows user to pick a file.
        /// </summary>
        /// <param name="windowTitle">The title of the window.</param>
        /// <param name="filter">
        /// The filter for file types, which will only be displayed.
        /// See https://learn.microsoft.com/en-us/dotnet/api/microsoft.win32.filedialog.filter?view=windowsdesktop-7.0 for more.
        /// </param>
        /// <returns>The path to the file if the user has picked a file; Otherwise null.</returns>
        public static string? DisplayOpenFileDialog(string windowTitle = "Select file", string filter = "All files (*.*)|*.*")
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = windowTitle,
                Filter = filter
            };
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }

        /// <summary>
        /// Compares if two given generic variables are equal.
        /// </summary>
        /// <returns>True if the values are equal; False if not.</returns>
        public static bool AreEqual<T>(T a, T b) => EqualityComparer<T>.Default.Equals(a, b);

        /// <summary>
        /// Checks if the given file is locked.
        /// </summary>
        /// <param name="filePath">The full path to the file.</param>
        /// <returns>True if the file is locked; False if not.</returns>
        public static bool IsFileLocked(string filePath)
        {
            FileInfo file = new(filePath);
            try
            {
                using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
            }
            catch (IOException)
            {
                // The file is unavailable because it is:
                // - still being written to
                // - is being processed by another thread
                // - does not exist (has already been processed)
                return true;
            }

            // File is not locked
            return false;
        }
    }
}