using System.Linq;

namespace System
{
    /// <summary>
    /// A class that contains multiple methods that extend existing string methods and add a new ones, like adding 
    /// case sensitive variants to existing methods and adds some now ones, like number of occurences or shorten.
    /// </summary>
    public static class StringFunctionsExtensions
    {
        /// <summary>
        /// Counts the total amount of occurences of <paramref name="character"/> in the <paramref name="text"/>.
        /// </summary>
        /// <param name="text">The text to search in.</param>
        /// <param name="character">The value to search for.</param>
        /// <returns>The total amount of occurences of character in the text.</returns>
        public static int CountOf(this string text, char character) => text.Count(f => f == character);

        /// <summary>
        /// Returns the index of the first occurence of any of the characters in the given text.
        /// </summary>
        /// <param name="text">The text to search in.</param>
        /// <param name="searchedValue">The values to be searched.</param>
        /// <returns>The index of the first occurence of any of the characters in the given text if one was found; Otherwise -1</returns>
        public static int IndexOfAny(this string text, params char[] searchedValue) => text.IndexOfAny(searchedValue);

        /// <summary>
        /// Trims the text from the start of the text to the first position of the searched value.
        /// </summary>
        /// <param name="text">The text to be trimmed.</param>
        /// <param name="searchedValue">The first value that the text will be trimmed to.</param>
        /// <param name="includeSearchedValue">Whether to include the searched value in the returned text or not. False by default.</param>
        /// <returns>The trimmed text.</returns>
        public static string TrimTo(this string text, string searchedValue, bool includeSearchedValue = false)
        {
            return includeSearchedValue
                ? text[..(text.IndexOf(searchedValue) + searchedValue.Length)]
                : text[..text.IndexOf(searchedValue)];
        }

        /// <summary>
        /// Trims the text from the first position of the searched value to the end of the string.
        /// </summary>
        /// <param name="text">The text to be trimmed.</param>
        /// <param name="searchedValue">The first value that the text will be trimmed to.</param>
        /// <param name="includeSearchedValue">Whether to include the searched value in the returned text or not. True by default.</param>
        /// <returns>The trimmed text.</returns>
        public static string TrimFrom(this string text, string searchedValue, bool includeSearchedValue = false) => includeSearchedValue ? text[text.IndexOf(searchedValue)..] : text[(text.IndexOf(searchedValue) + searchedValue.Length)..];

        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <param name="text">The string to seek.</param>
        /// <param name="searchedValue">The first value that the text will be trimmed to.</param>
        /// <param name="ignoreCase">Whether to ignore case sensitivity or not.</param>
        /// <returns>True if the value parameter occurs within this string; False if not.</returns>
        public static bool Contains(this string text, string searchedValue, bool ignoreCase) => ignoreCase ? text?.IndexOf(searchedValue, StringComparison.OrdinalIgnoreCase) >= 0 : text.Contains(searchedValue);

        /// <summary>
        /// Checks if the given <paramref name="text"/> contains at least one of the <paramref name="values"/>.
        /// </summary>
        /// <returns>True if the <paramref name="text"/> contains at least one of the values; False if not.</returns>
        public static bool ContainsAny(this string text, params char[] values) => values.Any(text.Contains);

        /// <summary>
        /// Checks if the given <paramref name="text"/> contains at least one of the <paramref name="values"/>.
        /// </summary>
        /// <returns>True if the <paramref name="text"/> contains at least one of the values; False if not.</returns>
        public static bool ContainsAny(this string text, params string[] values) => values.Any(text.Contains);

        /// <summary>
        /// Checks if the given <paramref name="text"/> starts with any of the values.
        /// </summary>
        /// <returns>True if the <paramref name="text"/> starts with one of the values, false if not.</returns>
        public static bool StartsWithAny(this string text, params char[] values) => values.Any(c => text.StartsWith(c.ToString()));

        /// <summary>
        /// Checks if the given <paramref name="text"/> starts with any of the values.
        /// </summary>
        /// <returns>True if the <paramref name="text"/> starts with one of the values, false if not.</returns>
        public static bool StartsWithAny(this string text, params string[] values) => values.Any(c => text.StartsWith(c));

        /// <summary>
        /// Removes the trailing zeroes from the string.
        /// </summary>
        public static string RemoveTrailingZeros(this string str) => str.IndexOf('.') == -1 ? str : str.TrimEnd('0').TrimEnd('.');

        /// <summary>
        /// Removes all occurences of <paramref name="strings"/> from the <paramref name="text"/>.
        /// </summary>
        public static string Remove(this string text, params string[] strings)
        {
            foreach (string item in strings)
            {
                text = text.Replace(item, string.Empty);
            }
            return text;
        }
    }
}