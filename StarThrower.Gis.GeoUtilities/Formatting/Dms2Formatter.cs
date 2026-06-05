/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Globalization;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    public class Dms2Formatter : IDmsFormatter
    {
        private static Dms2Formatter? _formatter;


        #region Construction

        private Dms2Formatter() { }

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

        public double DmsToDdNs(string dmsNs)
        {
            ArgumentNullException.ThrowIfNull(dmsNs);
            
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

        public double DmsToDdEw(string dmsEw)
        {
            ArgumentException.ThrowIfNullOrEmpty(dmsEw);
            //TODO: consider other invalid formatting problems
            

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


