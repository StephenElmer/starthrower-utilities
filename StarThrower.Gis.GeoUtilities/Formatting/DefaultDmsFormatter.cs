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
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.Formatting
{
    public class DefaultDmsFormatter : IDmsFormatter
    {
        private static DefaultDmsFormatter? _formatter = null;


        #region Construction

        private DefaultDmsFormatter() { }

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

        public double DmsToDdNs(string dmsNs)
        {
            return DMSToDD(dmsNs);
        }

        public double DmsToDdEw(string dmsEw)
        {
            return DMSToDD(dmsEw);
        }

        public string DdToDmsNs(double ddNs)
        {
            return DDToDMS(ddNs);
        }

        public string DdToDmsEw(double ddEw)
        {
            return DDToDMS(ddEw);
        }

        #endregion
    }
}


