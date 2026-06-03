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
        private static Dms2Formatter? _formatter = null;


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

        public double DmsToDdNs(string dmsNS)
        {
            if (dmsNS == null) throw new ArgumentNullException("dmsNS");
            
            // Declare the variables to be double precision floating-point.
            double degrees = 0;
            double minutes = 0;
            double seconds = 0;
            string dir = dmsNS[0].ToString();  //N|n|S|s

            //Set degree to value before between dmsNS[0] and {D|d}
            int dIndex = Math.Max(dmsNS.IndexOf('D'), dmsNS.IndexOf('d'));
            string deg = dmsNS.Substring(1, dIndex - 1);
            degrees = double.Parse(deg, CultureInfo.InvariantCulture);

            // Set minutes to the value between the "�" and the "'"
            // of the text string for the variable Degree_Deg divided by
            // 60. The Val function converts the text string to a number.
            int mIndex = Math.Max(dmsNS.IndexOf('M'), dmsNS.IndexOf('m'));
            string min = dmsNS.Substring(dIndex + 1, mIndex - (dIndex + 1));
            minutes = double.Parse(min, CultureInfo.InvariantCulture) / 60;

            // Set seconds to the number to the right of "'" that is
            // converted to a value and then divided by 3600.
            string sec = dmsNS.Substring(mIndex + 1, (dmsNS.Length - 1) - (mIndex + 1));
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

        public double DmsToDdEw(string dmsEW)
        {
            ArgumentException.ThrowIfNullOrEmpty(dmsEW);
            //TODO: consider other invalid formatting problems
            

            // Declare the variables to be double precision floating-point.
            double degrees = 0;
            double minutes = 0;
            double seconds = 0;
            string dir = dmsEW[0].ToString();  //E|e|w|w

            //Set degree to value before between dmsNS[0] and {D|d}
            int dIndex = Math.Max(dmsEW.IndexOf('D'), dmsEW.IndexOf('d'));
            string deg = dmsEW.Substring(1, dIndex - 1);
            degrees = double.Parse(deg, CultureInfo.InvariantCulture);

            // Set minutes to the value between the "�" and the "'"
            // of the text string for the variable Degree_Deg divided by
            // 60. The Val function converts the text string to a number.
            int mIndex = Math.Max(dmsEW.IndexOf('M'), dmsEW.IndexOf('m'));
            string min = dmsEW.Substring(dIndex + 1, mIndex - (dIndex + 1));
            minutes = double.Parse(min, CultureInfo.InvariantCulture) / 60;

            // Set seconds to the number to the right of "'" that is
            // converted to a value and then divided by 3600.
            string sec = dmsEW.Substring(mIndex + 1, (dmsEW.Length - 1) - (mIndex + 1));
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

        public string DdToDmsNs(double ddNS)
        {
            float Y = (float)Math.Abs(ddNS);
            int deg = (int)Math.Truncate(Y);
            float minTemp = ((Y - deg) * 60);
            int min = (int)Math.Truncate(minTemp);
            int sec = (int)Math.Truncate((minTemp - min) * 60);
            int dec = (int)Math.Truncate((((minTemp - min) * 60) - sec) * 100);
            string dir = (ddNS < 0 ? "S" : "N");
            return dir + deg.ToString(CultureInfo.InvariantCulture) + "d" + min.ToString(CultureInfo.InvariantCulture) + "m" + sec.ToString(CultureInfo.InvariantCulture) + "." + dec.ToString(CultureInfo.InvariantCulture) + "s";
        }

        public string DdToDmsEw(double ddEW)
        {
            float Y = (float)Math.Abs(ddEW);
            int deg = (int)Math.Truncate(Y);
            float minTemp = ((Y - deg) * 60);
            int min = (int)Math.Truncate(minTemp);
            int sec = (int)Math.Truncate((minTemp - min) * 60);
            int dec = (int)Math.Truncate((((minTemp - min) * 60) - sec) * 100);
            string dir = (ddEW < 0 ? "W" : "E");
            return dir + deg.ToString(CultureInfo.InvariantCulture) + "d" + min.ToString(CultureInfo.InvariantCulture) + "m" + sec.ToString(CultureInfo.InvariantCulture) + "." + dec.ToString(CultureInfo.InvariantCulture) + "s";
        }

        #endregion
    }
}


