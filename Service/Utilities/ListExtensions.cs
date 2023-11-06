using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TurtleToastService.Service.Utilities
{
    /// <summary>
    /// A class that holds method extensions for a System.Collections.Generic.List
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Removes elements from the <paramref name="collection"/> which are null or are empty/only contain whitespaces.
        /// </summary>
        public static IEnumerable<string> RemoveNullAndWhitespace(this IEnumerable<string> collection) => collection.Where(s => !string.IsNullOrWhiteSpace(s));

        /// <summary>
        /// Checks if any item of <paramref name="values"/> array contains the <paramref name="text"/>.
        /// </summary>
        /// <param name="values">The values to check in.</param>
        /// <param name="text">The text to compare.</param>
        /// <param name="ignoreCase">Whether to ignore case sensitivity or not.</param>
        /// <param name="emptyArrayIsTrue">Whether to treat the case where the array is empty as a true or not.</param>
        /// <returns>True if at least one value of <paramref name="values"/> array contains the <paramref name="text"/>.; False if not.</returns>
        public static bool Contains(this IEnumerable<string> values, string text, bool ignoreCase = false, bool emptyArrayIsTrue = false)
        {
            StringComparison comparison = ignoreCase
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;

            if (!values.Any())
                return emptyArrayIsTrue;
            else
                return values.Any(value => text.Contains(value, comparison));
        }

        /// <summary>
        /// Checks if the given list is null or empty.
        /// </summary>
        /// <returns>True if the list is null or empty; False if not.</returns>
        public static bool IsNullOrEmpty<T>(this List<T> list) => list == null || list.Count == 0;

        /// <summary>
        /// Replaces a char in each list element.
        /// </summary>
        /// <param name="list">The list to alternate.</param>
        /// <param name="oldChar">The char to be replaced.</param>
        /// <param name="newChar">The new char to replace all occurences of <paramref name="oldChar"/>.</param>
        /// <returns></returns>
        public static List<string> ReplaceForEach(this List<string> list, char oldChar, char newChar)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    list[i] = list[i].Replace(oldChar, newChar);
            }

            return list;
        }

        /// <summary>
        /// Trims each list element.
        /// </summary>
        /// <param name="list">The list to alternate.</param>
        /// <param name="trimValues">The characters to trim.</param>
        /// <returns>The alternated list.</returns>
        public static List<string> TrimEachEnd(this List<string> list, params char[] trimValues)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    list[i] = list[i].TrimEnd(trimValues);
            }

            return list;
        }

        /// <summary>
        /// Creates a list with the given element.
        /// </summary>
        public static List<T> CreateList<T>(this T element) => new() { element };

        /// <summary>
        /// Adds given items to the list.
        /// </summary>
        public static void Add<T>(this List<T> list, params T[] items) => list.AddRange(from T item in items select item);

        /// <summary>
        /// Adds a collection of items to the Observable collection.
        /// </summary>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items) => items.ToList().ForEach(collection.Add);

        /// <summary>
        /// Casts the given interface list to the class list, which implements that interface.
        /// </summary>
        /// <typeparam name="TInterface">The interface to cast from.</typeparam>
        /// <typeparam name="TClass">The to cast to, which implements the <typeparamref name="TInterface"/> interface.</typeparam>
        public static List<TClass> CastToList<TInterface, TClass>(this List<TInterface> interfaceList) where TClass : TInterface
        {
            return interfaceList.Select(item => (TClass)item).ToList();
        }

        /// <summary>
        /// Adds the list to itself.
        /// </summary>
        /// <example>
        /// List = "1,2"
        /// Count = 3
        /// 
        /// Returns: "1,2,1,2,1,2"
        /// </example>
        /// <param name="list">The list to duplicate.</param>
        /// <param name="count">The amount of duplicates of the <paramref name="list"/> that will be in the returned list. This includes the base instance.</param>
        public static List<T> Duplicate<T>(this List<T> list, int count = 2)
        {
            if (count < 2)
                throw new ArgumentException("The number of times to duplicate the collection must be at least 2.");

            var result = new List<T>();
            for (int i = 0; i < count; i++)
            {
                result.AddRange(list);
            }
            return result;
        }

        /// <summary>
        /// Removes the last item from the list.
        /// </summary>
        public static List<T> RemoveLast<T>(this List<T> list)
        {
            if (list.Count != 0)
                list.RemoveAt(list.Count - 1);
            return list;
        }
    }
}
