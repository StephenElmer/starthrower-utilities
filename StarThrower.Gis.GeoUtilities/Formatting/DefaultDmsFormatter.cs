// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    /// <summary>
    /// An <see cref="IDmsFormatter"/> implementation using the <see cref="DmsFormat.Dms1"/>
    /// style: <c>[-]d[d]d&#176; [m]m' ss.ss"</c>, e.g. <c>31&#176; 56' 31.13"</c> or
    /// <c>-31&#176; 56' 31.13"</c>. This formatter does not include an N/S/E/W designation;
    /// sign alone indicates direction.
    /// </summary>
    public class DefaultDmsFormatter : IDmsFormatter
    {
        private static DefaultDmsFormatter? _formatter;


        #region Construction

        private DefaultDmsFormatter() { }

        /// <summary>
        /// Gets the singleton instance of <see cref="DefaultDmsFormatter"/>.
        /// </summary>
        /// <returns>The singleton <see cref="DefaultDmsFormatter"/> instance.</returns>
        internal static DefaultDmsFormatter GetInstance()
        {
            if (_formatter == null)
            {
                _formatter = new DefaultDmsFormatter();
            }
            return _formatter;
        }

        #endregion


        #region IDmsFormatter Members

        private static double DMSToDD(string dms)
        {
            // Declare the variables to be double precision floating-point.
            double degrees = 0;
            double minutes = 0;
            double seconds = 0;
            bool isNeg = false;

            // Set degree to value before "�" of Argument Passed.
            string deg = StringUtil.GetToken(dms, " ", 1);
            if (dms[0].Equals('-'))
            {
                degrees = double.Parse(deg.AsSpan(1, deg.Length - 2), CultureInfo.InvariantCulture);
                isNeg = true;
            }
            else
            {
                degrees = double.Parse(deg.AsSpan(0, deg.Length - 1), CultureInfo.InvariantCulture);
                isNeg = false;
            }


            // Set minutes to the value between the "�" and the "'"
            // of the text string for the variable Degree_Deg divided by
            // 60. The Val function converts the text string to a number.
            string min = StringUtil.GetToken(dms, " ", 2);
            minutes = double.Parse(min.AsSpan(0, min.Length - 1), CultureInfo.InvariantCulture) / 60;

            // Set seconds to the number to the right of "'" that is
            // converted to a value and then divided by 3600.
            string sec = StringUtil.GetToken(dms, " ", 3);
            seconds = double.Parse(sec.AsSpan(0, sec.Length - 1), CultureInfo.InvariantCulture) / 3600;

            if (isNeg)
            {
                return -1 * (degrees + minutes + seconds);
            }
            else
            {
                return degrees + minutes + seconds;
            }
        }

        private static string DDToDMS(double dd)
        {
            float Y = (float)Math.Abs(dd);
            int deg = (int)Math.Truncate(Y);
            float minTemp = ((Y - deg) * 60);
            int min = (int)Math.Truncate(minTemp);
            int sec = (int)Math.Truncate((minTemp - min) * 60);
            int dec = (int)Math.Truncate((((minTemp - min) * 60) - sec) * 100);
            if (dd < 0)
            {
                deg *= -1;
            }
            return deg.ToString(CultureInfo.InvariantCulture) + StringUtil.DegreeSymbol + " " + min.ToString(CultureInfo.InvariantCulture) + "' " + sec.ToString(CultureInfo.InvariantCulture) + "." + dec.ToString(CultureInfo.InvariantCulture) + "\"";
        }

        /// <summary>
        /// Converts a north/south DMS string (<c>[-]d[d]d&#176; [m]m' ss.ss"</c>) to its
        /// decimal-degree equivalent.
        /// </summary>
        /// <param name="dmsNs">The north/south coordinate, formatted as DMS.</param>
        /// <returns>The decimal-degree value (negative for south).</returns>
        public double DmsToDdNs(string dmsNs)
        {
            return DMSToDD(dmsNs);
        }

        /// <summary>
        /// Converts an east/west DMS string (<c>[-]d[d]d&#176; [m]m' ss.ss"</c>) to its
        /// decimal-degree equivalent.
        /// </summary>
        /// <param name="dmsEw">The east/west coordinate, formatted as DMS.</param>
        /// <returns>The decimal-degree value (negative for west).</returns>
        public double DmsToDdEw(string dmsEw)
        {
            return DMSToDD(dmsEw);
        }

        /// <summary>
        /// Converts a decimal-degree north/south coordinate to its <c>d[d]d&#176; [m]m' ss.ss"</c> DMS representation.
        /// </summary>
        /// <param name="ddNs">The decimal-degree value (negative for south).</param>
        /// <returns>The coordinate formatted as DMS. No N/S designation is included; sign alone indicates direction.</returns>
        public string DdToDmsNs(double ddNs)
        {
            return DDToDMS(ddNs);
        }

        /// <summary>
        /// Converts a decimal-degree east/west coordinate to its <c>d[d]d&#176; [m]m' ss.ss"</c> DMS representation.
        /// </summary>
        /// <param name="ddEw">The decimal-degree value (negative for west).</param>
        /// <returns>The coordinate formatted as DMS. No E/W designation is included; sign alone indicates direction.</returns>
        public string DdToDmsEw(double ddEw)
        {
            return DDToDMS(ddEw);
        }

        #endregion
    }
}


