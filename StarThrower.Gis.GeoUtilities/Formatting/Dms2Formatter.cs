// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    /// <summary>
    /// An <see cref="IDmsFormatter"/> implementation using the <see cref="DmsFormat.Dms2"/>
    /// style: <c>{N|n|E|e|S|s|W|w}d[d]d{D|d}m[m]{M|m}s[s][.s[s]]{S|s}</c>, e.g.
    /// <c>S31d56m31.13s</c>, <c>n31D56M3.1S</c>, or <c>E3d2m3s</c>.
    /// </summary>
    public class Dms2Formatter : IDmsFormatter
    {
        private static Dms2Formatter? _formatter;


        #region Construction

        private Dms2Formatter() { }

        /// <summary>
        /// Gets the singleton instance of <see cref="Dms2Formatter"/>.
        /// </summary>
        /// <returns>The singleton <see cref="Dms2Formatter"/> instance.</returns>
        internal static Dms2Formatter GetInstance()
        {
            if (_formatter == null)
            {
                _formatter = new Dms2Formatter();
            }
            return _formatter;
        }

        #endregion


        #region IDmsFormatter Members

        /// <summary>
        /// Converts a north/south DMS string (<c>{N|n|S|s}d[d]d{D|d}m[m]{M|m}s[s][.s[s]]{S|s}</c>) to its
        /// decimal-degree equivalent.
        /// </summary>
        /// <param name="dmsNs">The north/south coordinate, formatted as DMS.</param>
        /// <returns>The decimal-degree value (negative for south).</returns>
        /// <exception cref="ArgumentException"><paramref name="dmsNs"/> is <see langword="null"/>, empty, or is not a validly formatted north/south DMS coordinate.</exception>
        public double DmsToDdNs(string dmsNs)
        {
            ArgumentException.ThrowIfNullOrEmpty(dmsNs);

            try
            {
                // Declare the variables to be double precision floating-point.
                double degrees = 0;
                double minutes = 0;
                double seconds = 0;
                string dir = dmsNs[0].ToString();  //N|n|S|s

                //Set degree to value before between dmsNS[0] and {D|d}
                int dIndex = Math.Max(dmsNs.IndexOf('D'), dmsNs.IndexOf('d'));
                string deg = dmsNs.Substring(1, dIndex - 1);
                degrees = double.Parse(deg, CultureInfo.InvariantCulture);

                // Set minutes to the value between the "�" and the "'"
                // of the text string for the variable Degree_Deg divided by
                // 60. The Val function converts the text string to a number.
                int mIndex = Math.Max(dmsNs.IndexOf('M'), dmsNs.IndexOf('m'));
                string min = dmsNs.Substring(dIndex + 1, mIndex - (dIndex + 1));
                minutes = double.Parse(min, CultureInfo.InvariantCulture) / 60;

                // Set seconds to the number to the right of "'" that is
                // converted to a value and then divided by 3600.
                string sec = dmsNs.Substring(mIndex + 1, (dmsNs.Length - 1) - (mIndex + 1));
                seconds = double.Parse(sec, CultureInfo.InvariantCulture) / 3600;

                if (dir.Equals("S", StringComparison.Ordinal) || dir.Equals("s", StringComparison.Ordinal))
                {
                    return -1 * (degrees + minutes + seconds);
                }
                else
                {
                    return degrees + minutes + seconds;
                }
            }
            catch (Exception ex) when (ex is FormatException or ArgumentOutOfRangeException or OverflowException)
            {
                throw new ArgumentException("The value is not a validly formatted north/south DMS coordinate.", nameof(dmsNs), ex);
            }
        }

        /// <summary>
        /// Converts an east/west DMS string (<c>{E|e|W|w}d[d]d{D|d}m[m]{M|m}s[s][.s[s]]{S|s}</c>) to its
        /// decimal-degree equivalent.
        /// </summary>
        /// <param name="dmsEw">The east/west coordinate, formatted as DMS.</param>
        /// <returns>The decimal-degree value (negative for west).</returns>
        /// <exception cref="ArgumentException"><paramref name="dmsEw"/> is <see langword="null"/>, empty, or is not a validly formatted east/west DMS coordinate.</exception>
        public double DmsToDdEw(string dmsEw)
        {
            ArgumentException.ThrowIfNullOrEmpty(dmsEw);

            try
            {
                // Declare the variables to be double precision floating-point.
                double degrees = 0;
                double minutes = 0;
                double seconds = 0;
                string dir = dmsEw[0].ToString();  //E|e|w|w

                //Set degree to value before between dmsNS[0] and {D|d}
                int dIndex = Math.Max(dmsEw.IndexOf('D'), dmsEw.IndexOf('d'));
                string deg = dmsEw.Substring(1, dIndex - 1);
                degrees = double.Parse(deg, CultureInfo.InvariantCulture);

                // Set minutes to the value between the "�" and the "'"
                // of the text string for the variable Degree_Deg divided by
                // 60. The Val function converts the text string to a number.
                int mIndex = Math.Max(dmsEw.IndexOf('M'), dmsEw.IndexOf('m'));
                string min = dmsEw.Substring(dIndex + 1, mIndex - (dIndex + 1));
                minutes = double.Parse(min, CultureInfo.InvariantCulture) / 60;

                // Set seconds to the number to the right of "'" that is
                // converted to a value and then divided by 3600.
                string sec = dmsEw.Substring(mIndex + 1, (dmsEw.Length - 1) - (mIndex + 1));
                seconds = double.Parse(sec, CultureInfo.InvariantCulture) / 3600;

                if (dir.Equals("W", StringComparison.Ordinal) || dir.Equals("w", StringComparison.Ordinal))
                {
                    return -1 * (degrees + minutes + seconds);
                }
                else
                {
                    return degrees + minutes + seconds;
                }
            }
            catch (Exception ex) when (ex is FormatException or ArgumentOutOfRangeException or OverflowException)
            {
                throw new ArgumentException("The value is not a validly formatted east/west DMS coordinate.", nameof(dmsEw), ex);
            }
        }

        /// <summary>
        /// Converts a decimal-degree north/south coordinate to its
        /// <c>{N|S}d[d]dms[s][.s[s]]s</c> DMS representation.
        /// </summary>
        /// <param name="ddNs">The decimal-degree value (negative for south).</param>
        /// <returns>The coordinate formatted as DMS with a leading "N" or "S" designation.</returns>
        public string DdToDmsNs(double ddNs)
        {
            float Y = (float)Math.Abs(ddNs);
            int deg = (int)Math.Truncate(Y);
            float minTemp = ((Y - deg) * 60);
            int min = (int)Math.Truncate(minTemp);
            int sec = (int)Math.Truncate((minTemp - min) * 60);
            int dec = (int)Math.Truncate((((minTemp - min) * 60) - sec) * 100);
            string dir = (ddNs < 0 ? "S" : "N");
            return dir + deg.ToString(CultureInfo.InvariantCulture) + "d" + min.ToString(CultureInfo.InvariantCulture) + "m" + sec.ToString(CultureInfo.InvariantCulture) + "." + dec.ToString(CultureInfo.InvariantCulture) + "s";
        }

        /// <summary>
        /// Converts a decimal-degree east/west coordinate to its
        /// <c>{E|W}d[d]dms[s][.s[s]]s</c> DMS representation.
        /// </summary>
        /// <param name="ddEw">The decimal-degree value (negative for west).</param>
        /// <returns>The coordinate formatted as DMS with a leading "E" or "W" designation.</returns>
        public string DdToDmsEw(double ddEw)
        {
            float Y = (float)Math.Abs(ddEw);
            int deg = (int)Math.Truncate(Y);
            float minTemp = ((Y - deg) * 60);
            int min = (int)Math.Truncate(minTemp);
            int sec = (int)Math.Truncate((minTemp - min) * 60);
            int dec = (int)Math.Truncate((((minTemp - min) * 60) - sec) * 100);
            string dir = (ddEw < 0 ? "W" : "E");
            return dir + deg.ToString(CultureInfo.InvariantCulture) + "d" + min.ToString(CultureInfo.InvariantCulture) + "m" + sec.ToString(CultureInfo.InvariantCulture) + "." + dec.ToString(CultureInfo.InvariantCulture) + "s";
        }

        #endregion
    }
}


