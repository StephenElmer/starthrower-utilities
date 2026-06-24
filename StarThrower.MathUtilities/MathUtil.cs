// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.MathUtilities
{
    public static class MathUtil
    {
        /// <summary>
        /// The mathmatical value of one degree.
        /// </summary>
        /// <remarks>
        /// The value of this constant is equivalent to Math.PI / 180.0.
        /// </remarks>
        public const double Degree = Math.PI / 180.0;

        /// <summary>
        /// Rounds a double to the whole number closest to zero.
        /// Doubles >= zero will have everything after the decimal truncated.
        /// Doubles less than zero will be rounded up to the nearest whole number.
        /// </summary>
        /// <param name="number">The number to be rounded.</param>
        /// <returns>The whole number closed to number on the zero side of number.</returns>
        /// <example>
        /// RoundTowardsZero(2.5) => 2
        /// RoundTowardsZero(0.5) => 0
        /// RoundTowardsZero(-0.5) => 0
        /// RoundTowardsZero(-2.5) => -2
        /// </example>
        public static long RoundTowardsZero(double number)
        {
            if (number >= 0)
            {
                return (long)Math.Floor(number);
            }
            return (long)Math.Ceiling(number);
        }

        /// <summary>
        /// Given a string, this function checks to see if it is equivalent to a numeric value
        /// </summary>
        /// <param name="test">The string to be checked</param>
        /// <returns>true if the string represents a numeric value; otherwise false.</returns>
        public static bool IsNumeric(string? test)
        {
            if (string.IsNullOrEmpty(test))
                return false;

            // Use NumberStyles.Any to match VB.NET's IsNumeric behavior
            // This accepts: currency, thousands separators, decimal points, scientific notation, etc.
            return double.TryParse(
                test,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out _);
        }

        /// <summary>
        /// Given a string, this function checks to see if it is equivalent to a whole number value
        /// </summary>
        /// <param name="test">The string to be checked</param>
        /// <returns>true if the string represents a whole number; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if test is null.</exception>
        public static bool IsWholeNumber(string? test)
        {
            ArgumentNullException.ThrowIfNull(test);

            double d = 0.0;
            if (!double.TryParse(test, out d)) return false;
            if (((d >= 0) ? Math.Floor(d) : Math.Ceiling(d)) != d) return false;
            return true;
        }

        /// <summary>
        /// Given a string, this function checks to see if it is equivalent to an integer value
        /// </summary>
        /// <param name="test">The string to be checked</param>
        /// <returns>true if the string represents an integer; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if test is null.</exception>
        /// <remarks>
        /// This function is similar to IsWholeNumber, but it checks for integer values specifically, which are whole numbers that can be represented within the range of the int data type in C#.
        /// </remarks>
        public static bool IsInteger(string? test)
        {
            ArgumentNullException.ThrowIfNull(test);

            int result = 0;
            if (!int.TryParse(test, out result)) return false;
            return true;
        }

        /// <summary>
        /// Given a string, this function checks to see if it is equivalent to a long value
        /// </summary>
        /// <param name="test">The string to be checked</param>
        /// <returns>true if the string represents a long; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if test is null.</exception>
        public static bool IsLong(string? test)
        {
            ArgumentNullException.ThrowIfNull(test);

            long result = 0;
            if (!long.TryParse(test, out result)) return false;
            return true;
        }

        /// <summary>
        /// Rounds a number to a specified number of decimal places, rounding half away from zero.
        /// </summary>
        /// <param name="value">The value to be rounded.</param>
        /// <param name="digits">The number of decimal places to round to. Any value less than or equal to zero rounds to the nearest whole number.</param>
        /// <returns>The rounded value.</returns>
        public static double RoundTo(double value, long digits)
        {
            double rv = 0;
            if (digits > 0)
            {
                rv = Math.Floor(value * Math.Pow(10.0, (double)digits) + 0.5);
                rv = rv / Math.Pow(10.0, digits);
            }
            else
            {
                rv = Math.Floor(value + 0.5);
            }

            return rv;
        }
    }
}
