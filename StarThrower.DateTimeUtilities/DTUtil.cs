// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.MathUtilities;
using StarThrower.StringUtilities;

namespace StarThrower.DateTimeUtilities
{
    /// <summary>
    /// A collection of functions that are useful when working with DateTime values.
    /// </summary>
    public static class DTUtil
    {
        /// <summary>
        /// Converts a DateTime to a string formatted MMDDYY.
        /// </summary>
        /// <param name="dt">The DateTime to be converted.</param>
        /// <returns>A string formatted MMDDYY.</returns>
        public static string ToMmddyyString(DateTime dt)
        {
            StringBuilder result = new StringBuilder(String.Empty);

            int month = dt.Month;
            int day = dt.Day;
            int year = dt.Year;

            if (month >= 10)
            {
                result.Append(month.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                result.Append("0" + month.ToString(CultureInfo.InvariantCulture));
            }

            if (day >= 10)
            {
                result.Append(day.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                result.Append("0" + day.ToString(CultureInfo.InvariantCulture));
            }

            result.Append(StringUtil.Right(year.ToString(CultureInfo.InvariantCulture), 2));

            return result.ToString();
        }

        /// <summary>
        /// Corrects a problem in Microsoft's DateDiff method.
        /// Returns the result of subtracting date1 from date2 (date2 - date1) in the units specified by interval.
        /// </summary>
        /// <param name="interval">The units (Year, Month, Weekday, Day, Hour, Minute, Second) in which you want the result.</param>
        /// <param name="date1">The first date.</param>
        /// <param name="date2">The second date.</param>
        /// <returns>date2 - date1 in the specified units.</returns>
        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {
            TimeSpan ts = date2 - date1;
            switch (interval)
            {
                case DateInterval.Year:
                    return date2.Year - date1.Year - ((date1.Month > date2.Month) || (date1.Month == date2.Month && date1.Day > date2.Day) ? 1 : 0);
                case DateInterval.Month:
                    return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                case DateInterval.Weekday:
                    //TODO: #43 — computes a week count; DateInterval.Weekday's doc describes a day name instead
                    return MathUtil.RoundTowardsZero(ts.TotalDays) / 7;
                case DateInterval.Day:
                    return MathUtil.RoundTowardsZero(ts.TotalDays);
                case DateInterval.Hour:
                    return MathUtil.RoundTowardsZero(ts.TotalHours);
                case DateInterval.Minute:
                    return MathUtil.RoundTowardsZero(ts.TotalMinutes);
                default:
                    return MathUtil.RoundTowardsZero(ts.TotalSeconds);
            }
        }

        /// <summary>
        /// Converts a DateTime into an ISO 8601 formatted string, treating it as UTC and formatting
        /// with a "+00:00" offset regardless of the DateTime's actual <see cref="DateTimeKind"/>.
        /// </summary>
        /// <param name="dt">The DateTime to be converted.</param>
        /// <returns>An ISO 8601 string with 7 fractional-second digits and a "+00:00" offset.</returns>
        /// <remarks>
        /// See http://www.w3.org/TR/NOTE-datetime for more information on the ISO 8601 standard.
        /// <para>
        /// The original (pre-2026-06) hand-rolled implementation of this method produced a malformed
        /// fractional-seconds component for any DateTime with a nonzero Millisecond value: it formatted
        /// the fraction as <c>(Millisecond / 1000.0).ToString()</c> (e.g. "0.5") and appended that whole
        /// string after an already-appended decimal point, yielding a double decimal point such as
        /// "...:30.0.5" instead of "...:30.500". The current implementation delegates to the BCL
        /// round-trip ("o") format, which does not have this defect, but also always emits 7 fractional
        /// digits rather than a variable-precision fraction — output strings from this method are
        /// therefore longer than those produced before this change.
        /// </para>
        /// </remarks>
        [Obsolete("Use new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc)).ToString(\"o\", CultureInfo.InvariantCulture) instead.")]
        public static string DateTimeToIso8601(DateTime dt)
        {
            return new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc)).ToString("o", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts an ISO 8601 string to a DateTime.
        /// </summary>
        /// <param name="iso">The string to be converted.</param>
        /// <returns>The DateTime value represented by iso.</returns>
        /// <remarks>
        /// See http://www.w3.org/TR/NOTE-datetime for more information on the ISO 8601 standard.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if iso is null.</exception>
        [Obsolete("Use DateTimeOffset.Parse(iso, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal).UtcDateTime instead.")]
        public static DateTime Iso8601ToDateTime(string? iso)
        {
            ArgumentNullException.ThrowIfNull(iso);

            return DateTimeOffset.Parse(
                iso,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal).UtcDateTime;
        }

        /// <summary>
        /// Truncates a DateTime to whole-second precision, discarding any fractional seconds.
        /// </summary>
        /// <param name="dt">The DateTime to be truncated.</param>
        /// <returns>A new DateTime equal to <paramref name="dt"/> with the milliseconds component removed.</returns>
        /// <remarks>
        /// This method always discards (floors) the millisecond remainder; it does not round to the
        /// nearest second. For example, 12:00:00.900 becomes 12:00:00, not 12:00:01.
        /// </remarks>
        public static DateTime TruncateToSeconds(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }

        /// <summary>
        /// Truncates a DateTime to whole-second precision, discarding any fractional seconds.
        /// </summary>
        /// <param name="dt">The DateTime to be truncated.</param>
        /// <returns>A new DateTime equal to <paramref name="dt"/> with the milliseconds component removed.</returns>
        /// <remarks>
        /// This method always discards (floors) the millisecond remainder; despite its name, it does not
        /// round to the nearest second. For example, 12:00:00.900 becomes 12:00:00, not 12:00:01.
        /// </remarks>
        [Obsolete("Use TruncateToSeconds(DateTime) instead. This method truncates rather than rounds, despite its name.")]
        public static DateTime RoundToSeconds(DateTime dt)
            => TruncateToSeconds(dt);
    }
}
