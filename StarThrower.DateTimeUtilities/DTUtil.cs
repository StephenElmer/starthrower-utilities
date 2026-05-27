using System;
using System.Globalization;
using System.Text;
using StarThrower.Logging;
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
            try
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
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DTUtil.ToMMDDYYString(DateTime)", ex);
                throw;
            }
        }

        /// <summary>
        /// Corrects a problem in Microsoft's DateDiff method.
        /// Returns the result of subtracting date1 from date2 (date2 - date1) in the units specified by interval.
        /// </summary>
        /// <param name="interval">The units (Year, Month, Day, Hour, Minutes, Seconds) in which you want the result.</param>
        /// <param name="date1">The first date.</param>
        /// <param name="date2">The second date.</param>
        /// <returns>date2 - date1 in the specified units.</returns>
        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {
            try
            {
                TimeSpan ts = date2 - date1;
                switch (interval)
                {
                    case DateInterval.Year:
                        return date2.Year - date1.Year - ((date1.Month > date2.Month) || (date1.Month == date2.Month && date1.Day > date2.Day) ? 1 : 0);
                    case DateInterval.Month:
                        return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                    case DateInterval.Weekday:
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
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DTUtil.DateDiff(DateInterval, DateTime, DateTime)", ex);
                throw;
            }
        }

        /// <summary>
        /// Converts a DateTime into an ISO 8601 formatted string.
        /// </summary>
        /// <param name="dt">The DateTime to be converted.</param>
        /// <returns>An ISO 8601 string.</returns>
        /// <remarks>
        /// See http://www.w3.org/TR/NOTE-datetime for more information on the ISO 8601 standard.
        /// </remarks>
        public static string DateTimeToIso8601(DateTime dt)
        {
            try
            {
                string YYYY = null;
                string MM = null;
                string DD = null;
                string hh = null;
                string mm = null;
                string ss = null;
                string s = null;
                string TZD = "+00:00";

                if (dt.Year < 10)
                {
                    YYYY = "000" + dt.Year.ToString(CultureInfo.InvariantCulture);
                }
                else if (dt.Year < 100)
                {
                    YYYY = "00" + dt.Year.ToString(CultureInfo.InvariantCulture);
                }
                else if (dt.Year < 1000)
                {
                    YYYY = "0" + dt.Year.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    YYYY = dt.Year.ToString(CultureInfo.InvariantCulture);
                }

                if (dt.Month < 10)
                {
                    MM = "0" + dt.Month.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    MM = dt.Month.ToString(CultureInfo.InvariantCulture);
                }

                if (dt.Day < 10)
                {
                    DD = "0" + dt.Day.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    DD = dt.Day.ToString(CultureInfo.InvariantCulture);
                }

                if (dt.Hour < 10)
                {
                    hh = "0" + dt.Hour.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    hh = dt.Hour.ToString(CultureInfo.InvariantCulture);
                }

                if (dt.Minute < 10)
                {
                    mm = "0" + dt.Minute.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    mm = dt.Minute.ToString(CultureInfo.InvariantCulture);
                }

                if (dt.Second < 10)
                {
                    ss = "0" + dt.Second.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    ss = dt.Second.ToString(CultureInfo.InvariantCulture);
                }

                double frac = dt.Millisecond / 1000.0;
                s = frac.ToString(CultureInfo.InvariantCulture);

                StringBuilder sb = new StringBuilder();

                sb.Append(YYYY + "-");
                sb.Append(MM + "-");
                sb.Append(DD + "T");
                sb.Append(hh + ":");
                sb.Append(mm + ":");
                sb.Append(ss + ".");
                sb.Append(s);
                sb.Append(TZD);

                return sb.ToString();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DTUtil.DateTimeToIso8601(DateTime)", ex);
                throw;
            }
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
        public static DateTime Iso8601ToDateTime(string iso)
        {
            if (iso == null) throw new ArgumentNullException("iso");

            try
            {
                //TODO: this still needs some work - 
                //      it doesn't yet handle the TZD time zone designator correctly
                //      nor do I think it handles the fractional seconds correctly - ISO8601 indicates that the fractional seconds is actually a fraction, not milliseconds
                string strDelim1 = "T";
                char[] chrDelim1 = strDelim1.ToCharArray();
                string[] split1 = iso.Split(chrDelim1);

                //DateTime outDate = DateTime.Parse(split1[0] + " " + split1[1]);
                //return outDate;

                string strDelim2 = String.Empty;
                char[] chrDelim2 = null;
                string time = split1[1];
                string newTime = null;
                string[] split2 = null;
                if (time.Contains("+"))
                {
                    strDelim2 = "+";
                    chrDelim2 = strDelim2.ToCharArray();
                    split2 = time.Split(chrDelim2);
                    newTime = split2[0];
                }
                else if (time.Contains("-"))
                {
                    strDelim2 = "-";
                    chrDelim2 = strDelim2.ToCharArray();
                    split2 = time.Split(chrDelim2);
                    newTime = split2[0];
                }
                else
                {
                    newTime = time;
                }

                DateTime outDate = DateTime.Parse(split1[0] + " " + newTime, CultureInfo.InvariantCulture);
                return outDate;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DTUtil.Iso8601ToDateTime(string)", ex);
                throw;
            }

        }

        public static DateTime RoundToSeconds(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }
    }
}
