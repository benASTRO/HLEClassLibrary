using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HLE.Properties;

namespace HLE.Strings
{

    /// <summary>
    /// A class to help with any kind of <see cref="string"/>.
    /// </summary>
    public static class StringHelper
    {
        private static readonly Regex _spacePattern = new(@"\s", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250));

        /// <summary>
        /// Counts the given <see cref="char"/> <paramref name="c"/> in the <see cref="string"/> <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> in which the <see cref="char"/> will be counted in.</param>
        /// <param name="c">The counted <see cref="char"/>.</param>
        /// <returns>The amount of the given <see cref="char"/> in the <see cref="string"/> <paramref name="str"/>.</returns>
        public static long CountChar(this string str, char c)
        {
            return str.ToCharArray().Where(cc => cc == c).LongCount();
        }

        /// <summary>
        /// Decodes a <see cref="byte"/> <see cref="Array"/> to a <see cref="string"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/> array that will be decoded.</param>
        /// <returns>Returns the decoded array as a <see cref="string"/>.</returns>
        public static string Decode(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Encodes a <see cref="string"/> to a <see cref="byte"/> array.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be encoded.</param>
        /// <returns>Returns the encoded <see cref="string"/> as a <see cref="byte"/> array.</returns>
        public static byte[] Encode(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// Matches the input <see cref="string"/> <paramref name="str"/> for the given Regex <paramref name="pattern"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be matches with the <paramref name="pattern"/>.</param>
        /// <param name="pattern">The Regex <paramref name="pattern"/> for the match.</param>
        /// <returns>Returns true, if <paramref name="str"/> matches at least once, false otherwise.</returns>
        public static bool IsMatch(this string str, string pattern)
        {
            return new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(str);
        }

        /// <summary>
        /// Matches the input <see cref="string"/> <paramref name="str"/> for the given Regex <paramref name="pattern"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be matches with the <paramref name="pattern"/>.</param>
        /// <param name="pattern">The Regex <paramref name="pattern"/> for the match.</param>
        /// <returns>Returns the <see cref="string"/> that matches the Regex <paramref name="pattern"/>.</returns>
        public static string Match(this string str, string pattern)
        {
            return new Regex(pattern, RegexOptions.IgnoreCase).Match(str).Value;
        }

        /// <summary>
        /// Matches the input <see cref="string"/> <paramref name="str"/> for the given Regex <paramref name="pattern"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be matches with the <paramref name="pattern"/>.</param>
        /// <param name="pattern">The Regex <paramref name="pattern"/> for the match.</param>
        /// <returns>Returns a <see cref="List{String}"/> that contains every match of the input <see cref="string"/> <paramref name="str"/>.</returns>
        public static IEnumerable<string> Matches(this string str, string pattern)
        {
            return new Regex(pattern, RegexOptions.IgnoreCase).Matches(str).Select(m => m.Value);
        }

        /// <summary>
        /// Removes the given <see cref="string"/> <paramref name="stringToRemove"/> from the input <see cref="string"/> <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> from with the given <see cref="string"/> <paramref name="stringToRemove"/> will be removed.</param>
        /// <param name="stringToRemove">The <see cref="string"/> that will be removed from the input <see cref="string"/> <paramref name="str"/>.</param>
        /// <returns>Returns the <see cref="string"/> <paramref name="str"/> with the <paramref name="stringToRemove"/> removed.</returns>
        public static string Remove(this string str, string stringToRemove)
        {
            return str.Replace(stringToRemove, "");
        }

        /// <summary>
        /// Removes the <see cref="Resources.ChatterinoChar"/> from the input <see cref="string"/> <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> from which the <see cref="char"/> will be removed.</param>
        /// <returns>Returns the input <see cref="string"/> <paramref name="str"/> with the <see cref="Resources.ChatterinoChar"/> removed.</returns>
        public static string RemoveChatterinoChar(this string str)
        {
            return str.Replace(Resources.ChatterinoChar, "");
        }

        /// <summary>
        /// Removes SQL characters from a <see cref="string"/> that would lead to conflicts in queries.
        /// </summary>
        /// <param name="str">The <see cref="string"/> in which the characters will be removed.</param>
        /// <returns>Returns the <paramref name="str"/> without conflict causing characters.</returns>
        public static string RemoveSQLChars(this string str)
        {
            new List<string>() { "'", "\"", "\\", }.ForEach(c => str = str.Replace(c, ""));
            return str;
        }

        /// <summary>
        /// Replaces the Regex match of the <paramref name="pattern"/> in the input <see cref="string"/> <paramref name="str"/> with the <paramref name="replacement"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> in which the match will be replaced.</param>
        /// <param name="pattern">The Regex pattern for the match.</param>
        /// <param name="replacement">The <paramref name="replacement"/> that will be put into the input <see cref="string"/> <paramref name="str"/>.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> with the matching part replaced by the <paramref name="replacement"/>.</returns>
        public static string ReplacePattern(this string str, string pattern, string replacement)
        {
            return Regex.Replace(str, pattern, replacement, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Replaces multiple following spaces in the input <see cref="string"/> <paramref name="str"/> with only one space.
        /// </summary>
        /// <param name="str">The input <see cref="string"/> in which the spaces will be replaced.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> with multiple following spaces replaced.</returns>
        public static string ReplaceSpaces(this string str)
        {
            return str.ReplacePattern(@"\s+", " ");
        }

        public static IEnumerable<string> Split(this string str, int charCount)
        {
            if (str.Length <= charCount)
            {
                return new string[] { str };
            }
            List<string> result = new();
            while (str.Length > charCount)
            {
                result.Add(str[..charCount]);
                str = str[charCount..];
            }
            result.Add(str);
            return result;
        }

        public static bool HasSpaces(this string str)
        {
            return _spacePattern.IsMatch(str);
        }

        /// <summary>
        /// Converts a <see cref="string"/> to an <see cref="int"/>.<br />
        /// Only works, if the input <see cref="string"/> <paramref name="str"/> contains only numbers.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be converted to a number.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> converted to an <see cref="int"/>.</returns>
        public static int ToInt(this string str)
        {
            return Convert.ToInt32(str);
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="long"/>.<br />
        /// Only works, if the input <see cref="string"/> <paramref name="str"/> contains only numbers.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be converted to a number.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> converted to a <see cref="long"/>.</returns>
        public static long ToLong(this string str)
        {
            return Convert.ToInt64(str);
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="short"/>.<br />
        /// Only works, if the input <see cref="string"/> <paramref name="str"/> contains only numbers.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be converted to a number.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> converted to an <see cref="short"/>.</returns>
        public static short ToShort(this string str)
        {
            return Convert.ToInt16(str);
        }

        /// <summary>
        /// Converts a <see cref="string"/> to an <see cref="uint"/>.<br />
        /// Only works, if the input <see cref="string"/> <paramref name="str"/> contains only numbers.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be converted to a number.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> converted to an <see cref="uint"/>.</returns>
        public static uint ToUInt(this string str)
        {
            return Convert.ToUInt32(str);
        }

        /// <summary>
        /// Converts a <see cref="string"/> to an <see cref="ulong"/>.<br />
        /// Only works, if the input <see cref="string"/> <paramref name="str"/> contains only numbers.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be converted to a number.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> converted to an <see cref="ulong"/>.</returns>
        public static ulong ToULong(this string str)
        {
            return Convert.ToUInt64(str);
        }

        /// <summary>
        /// Converts a <see cref="string"/> to an <see cref="ushort"/>.<br />
        /// Only works, if the input <see cref="string"/> <paramref name="str"/> contains only numbers.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be converted to a number.</param>
        /// <returns>The input <see cref="string"/> <paramref name="str"/> converted to an <see cref="ushort"/>.</returns>
        public static ushort ToUShort(this string str)
        {
            return Convert.ToUInt16(str);
        }

        public static byte ToByte(this string str)
        {
            return Convert.ToByte(str);
        }

        public static sbyte ToSByte(this string str)
        {
            return Convert.ToSByte(str);
        }

        /// <summary>
        /// Trims all spaces in the beginning, end and middle of the <see cref="string"/> <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The <see cref="string"/> that will be trimmed.</param>
        /// <returns>A trimmed <see cref="string"/>.</returns>
        public static string TrimAll(this string str)
        {
            return str.Trim().ReplaceSpaces();
        }

        /// <summary>
        /// Returns a <see cref="string"/> that contains the given amount <paramref name="count"/> of spaces.
        /// </summary>
        /// <param name="count">The amount of spaces the <see cref="string"/> will contain.</param>
        /// <returns>The <see cref="string"/> filled with whitespaces.</returns>
        public static string Whitespace(int count)
        {
            return new string(' ', count);
        }

        public static StringBuilder Append(this StringBuilder builder, params string[] strings)
        {
            foreach (string s in strings)
            {
                builder.Append(s);
            }
            return builder;
        }
    }
}
