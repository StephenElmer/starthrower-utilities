// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.MathUtilities;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// This component provides conversions from Geodetic coordinates (yLat
    /// and xLon in radians) to a GEOREF coordinate string.
    /// </summary>
    /// <remarks>
    /// REFERENCES:
    /// 
    ///    Further information on GEOREF can be found in the Reuse Manual.
    /// 
    ///    GEOREF originated from :  U.S. Army Topographic Engineering Center
    ///                              Geospatial Information Division
    ///                              7701 Telegraph Road
    ///                              Alexandria, VA  22310-3864
    /// </remarks>
    public class GeorefWgs84 : GeographicCoordinateSystem
    {
        private const int LATITUDE_LOW = -90; //Minimum yLat
        private const int LATITUDE_HIGH = 90; //Maximum yLat
        private const int LONGITUDE_LOW = -180; //Minimum xLon
        private const int LONGITUDE_HIGH = 360; //Maximum xLon
        private const int MIN_PER_DEG = 60; //Number of minutes per degree
        private const int GEOREF_MINIMUM = 4; //Minimum number of chars for GEOREF
        private const int GEOREF_MAXIMUM = 14; //Maximum number of chars for GEOREF
        private const int GEOREF_LETTERS = 4; //Number of letters in GEOREF string
        private const int MAX_PRECISION = 5; //Maximum precision of minutes part
        private const int LETTER_I = 8; //Index for letter I
        private const int LETTER_M = 12; //Index for letter M
        private const int LETTER_O = 14; //Index for letter O
        private const int LETTER_Q = 16; //Index for letter Q
        private const int LETTER_Z = 25; //Index for letter Z
        private const int LETTER_A_OFFSET = 65; //Letter A offset in character set
        private const int ZERO_OFFSET = 48; //Number zero offset in character set
        private const int QUAD = 15; //Degrees per grid square
        private const double ROUND_ERROR = 0.0000005; //Rounding factor


        #region Construction

        internal GeorefWgs84() : base()
        {
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Extracts the yLat and xLon degree parts of the 
        /// GEOREF string.  The yLat and xLon degree parts are the first four
        /// characters.
        /// </summary>
        /// <param name="coordString">GEOREF string.</param>
        /// <param name="xLon">Longitude in degrees.</param>
        /// <param name="yLat">Latitude in degrees.</param>
        private static void ExtractDegrees(string coordString, ref double xLon, ref double yLat)
        {
            int[] letter_number = new int[GEOREF_LETTERS]; //number corresponding to letter

            for (int i = 0; i < GEOREF_LETTERS; i++)
            {
                switch(coordString[i].ToString().ToUpper(CultureInfo.InvariantCulture))
                {
                    case "A":
                        letter_number[i] = 0;
                        break;
                    case "B":
                        letter_number[i] = 1;
                        break;
                    case "C":
                        letter_number[i] = 2;
                        break;
                    case "D":
                        letter_number[i] = 3;
                        break;
                    case "E":
                        letter_number[i] = 4;
                        break;
                    case "F":
                        letter_number[i] = 5;
                        break;
                    case "G":
                        letter_number[i] = 6;
                        break;
                    case "H":
                        letter_number[i] = 7;
                        break;
                    case "J":
                        letter_number[i] = 8;
                        break;
                    case "K":
                        letter_number[i] = 9;
                        break;
                    case "L":
                        letter_number[i] = 10;
                        break;
                    case "M":
                        letter_number[i] = 11;
                        break;
                    case "N":
                        letter_number[i] = 12;
                        break;
                    case "P":
                        letter_number[i] = 13;
                        break;
                    case "Q":
                        letter_number[i] = 14;
                        break;
                    case "R":
                        letter_number[i] = 15;
                        break;
                    case "S":
                        letter_number[i] = 16;
                        break;
                    case "T":
                        letter_number[i] = 17;
                        break;
                    case "U":
                        letter_number[i] = 18;
                        break;
                    case "V":
                        letter_number[i] = 19;
                        break;
                    case "W":
                        letter_number[i] = 20;
                        break;
                    case "X":
                        letter_number[i] = 21;
                        break;
                    case "Y":
                        letter_number[i] = 22;
                        break;
                    case "Z":
                        letter_number[i] = 23;
                        break;
                    default:
                        throw new FormatException();
                }
            }

            if (letter_number[2] > 14)
            {
                //bad longitude value
                throw new Exceptions.ValueOutOfRangeException();
            }
            if ((letter_number[1] > 11) || (letter_number[3] > 14))
            {
                //bad latitude value
                throw new Exceptions.ValueOutOfRangeException();
            }
            yLat = (double)(letter_number[1]) * QUAD + (double)(letter_number[3]);
            xLon = (double)(letter_number[0]) * QUAD + (double)(letter_number[2]);
        }

        /// <summary>
        /// Round value to nearest integer, using standard engineering rule.
        /// </summary>
        /// <param name="value">The value to be rounded.</param>
        /// <returns>The value rounded to the nearest integer value.</returns>
        private static long RoundGEOREF(double value)
        {
            //TODO: test to make sure these are correct:

            ////The original code
            //double ivalue = 0.0;
            //long ival = 0;
            //double fraction = modf(value, ref ivalue);
            //ival = (long)(ivalue);
            //if ((fraction > 0.5) || ((fraction == 0.5) && (ival % 2 == 1)))
            //{
            //    ival++;
            //}
            //return (ival);

            ////The second go
            //long iVal = Math.Truncate(value);
            //double fraction = value - iVal;
            //if ((fraction > 0.5) || ((fraction == 0.5) && (ival % 2 == 1)))
            //{
            //    iVal++;
            //}
            //return iVal;

            //The final go
            return Convert.ToInt64(MathUtil.RoundTo(value, 0));
        }

        /// <summary>
        /// Converts minutes to a string of length precision.
        /// </summary>
        /// <param name="minutes">Minutes to be converted</param>
        /// <param name="precision">Length of resulting string</param>
        /// <returns>A String representation of the converted minutes.</returns>
        private static string ConvertMinutesToString(double minutes, long precision)
        {
            double divisor = Math.Pow(10.0, (5 - precision));

            if (minutes == 60.0)
            {
                minutes = 59.999;
            }
            minutes = minutes * 1000;
            
            long min = RoundGEOREF(minutes / divisor);

            StringBuilder result = new StringBuilder(String.Empty);
            StringBuilder precisionString = new StringBuilder(String.Empty);
            for (int i = 0; i < precision; i++)
            {
                precisionString.Append('0');
            }
            result.Append(String.Format(CultureInfo.InvariantCulture, precisionString + "." + precisionString, min));
            
            if (precision == 1)
            {
                result.Append('0');
            }

            return result.ToString();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Converts a GEOREF coordinate string to Geodetic (yLat and xLon in radians) coordinates.
        /// </summary>
        /// <param name="coordValue">GEOREF coordinate string</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing Geodetic coordinates (Latitude, Longitude in radians, Height in meters).</returns>
        public ITranslationResult ToGeodetic(string coordValue)
        {
            ArgumentNullException.ThrowIfNull(coordValue);
            
            double xLon = 0.0;
            double yLat = 0.0;
            double zAlt = 0.0;

            double origin_long = (double)LONGITUDE_LOW; //Origin xLon
            double origin_lat = (double)LATITUDE_LOW; //Origin yLat
            int georef_length = coordValue.Length; //length of GEOREF string
            if ((georef_length < GEOREF_MINIMUM) || (georef_length > GEOREF_MAXIMUM) || ((georef_length % 2) != 0))
            {
                throw new FormatException();
            }

            ExtractDegrees(coordValue, ref xLon, ref yLat);
            
            int start = GEOREF_LETTERS; //Position in the GEOREF string
            int minutes_length = (georef_length - start) / 2; //length of minutes in the GEOREF string
            string temp = coordValue.Substring(start, minutes_length);
            double long_minutes = 0.0; //Longitude minute part of GEOREF
            if (!double.TryParse(temp, out long_minutes))
            {
                throw new FormatException();
            }

            temp = coordValue.Substring(start + minutes_length, minutes_length);
            double lat_minutes = 0.0; //Latitude minute part of GEOREF
            if (!double.TryParse(temp, out lat_minutes))
            {
                throw new FormatException();
            }
            
            yLat = yLat + origin_lat + lat_minutes / (double)MIN_PER_DEG;
            xLon = xLon + origin_long + long_minutes / (double)MIN_PER_DEG;


            return ToGeodetic(xLon, yLat, zAlt);
        }

        /// <summary>
        /// Translates the specified coordinates from GCS WGS84 to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">Longitude value in Geodetic coordinates (degrees).</param>
        /// <param name="yLat">Longitude value in Geodetic coordinates (degrees).</param>
        /// <param name="zAlt">Altitude value in Geodetic coordinates (meters).</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing Geodetic coordinates (Latitude, Longitude in radians, Height in meters).</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            double resultX = 0.0;
            double resultY = 0.0;
            double resultZ = 0.0;

            //translate from degrees to radians
            resultX = xLon * GeoUtil.DegreesToRadians;
            resultY = yLat * (Math.PI / 180.0);

            return new Translations.GenericResult(resultX, resultY, resultZ);
        }

        /// <summary>
        /// Converts Geodetic (yLat and xLon in radians)
        /// coordinates to a GEOREF coordinate string.  Precision specifies the
        /// number of digits in the GEOREF string for yLat and xLon:
        ///                                 0 for nearest degree
        ///                                 1 for nearest ten minutes
        ///                                 2 for nearest minute
        ///                                 3 for nearest tenth of a minute
        ///                                 4 for nearest hundredth of a minute
        ///                                 5 for nearest thousandth of a minute
        /// </summary>
        /// <param name="xLon">Longitude in radians.</param>
        /// <param name="yLat">Latitude in radians.</param>
        /// <param name="zAlt">Height in meters.</param>
        /// <param name="precision">Precision specified by the user.</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        public static ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt, long precision)
        {
            //Initialize, Validate, and convert to Degrees
            double originXLon = (double)LONGITUDE_LOW;
            double originYLat = (double)LATITUDE_LOW;

            yLat = yLat * GeoUtil.RadiansToDegrees;
            if ((yLat < (double)LATITUDE_LOW) || (yLat > (double)LATITUDE_HIGH))
            {
                throw new Exceptions.ValueOutOfRangeException();
            }
            
            xLon = xLon * GeoUtil.RadiansToDegrees;
            if ((xLon < (double)LONGITUDE_LOW) || (xLon > (double)LONGITUDE_HIGH))
            {
                throw new Exceptions.ValueOutOfRangeException();
            }
            if (xLon > 180)
            {
                xLon -= 360;
            }
            
            if ((precision < 0) || (precision > MAX_PRECISION))
            {
                throw new Exceptions.PrecisionException();
            }


            //Build the letter_number array
            long[] letter_number = new long[GEOREF_LETTERS + 1]; //GEOREF letters

            letter_number[0] = (long)((xLon - originXLon) / QUAD + ROUND_ERROR);
            
            xLon = xLon - ((double)letter_number[0] * QUAD + originXLon);
            letter_number[2] = (long)(xLon + ROUND_ERROR);

            double minutesXLon = (xLon - (double)letter_number[2]) * (double)MIN_PER_DEG; //GEOREF xLon minute part
            letter_number[1] = (long)((yLat - originYLat) / QUAD + ROUND_ERROR);
            
            yLat = yLat - ((double)letter_number[1] * QUAD + originYLat);
            letter_number[3] = (long)(yLat + ROUND_ERROR);

            double minutesYLat = (yLat - (double)letter_number[3]) * (double)MIN_PER_DEG; //GEOREF yLat minute part
            for (int i = 0; i < GEOREF_LETTERS; i++)
            {
                if (letter_number[i] >= LETTER_I)
                {
                    letter_number[i] += 1;
                }
                if (letter_number[i] >= LETTER_O)
                {
                    letter_number[i] += 1;
                }
            }

            if (letter_number[0] == 26) //xLon of 180 degrees
            { 
                letter_number[0] = LETTER_Z;
                letter_number[2] = LETTER_Q;
                minutesXLon = 59.999;
            }
            if (letter_number[1] == 13) //yLat of 90 degrees
            { 
                letter_number[1] = LETTER_M;
                letter_number[3] = LETTER_Q;
                minutesYLat = 59.999;
            }


            //Build the coordinate string
            StringBuilder coordString = new StringBuilder(String.Empty);

            for (int i = 0; i < 4; i++)
            {
                coordString.Append((char)(letter_number[i] + LETTER_A_OFFSET));
            }
            string minutesXLonText = ConvertMinutesToString(minutesXLon, precision);
            string minutesYLatText = ConvertMinutesToString(minutesYLat, precision);
            coordString.Append(minutesXLonText);
            coordString.Append(minutesYLatText);

            return new Translations.StringResult(xLon, yLat, zAlt, coordString.ToString());
        }

        /// <summary>
        /// Converts Geodetic (yLat and xLon in radians)
        /// coordinates to a GEOREF coordinate string.  Precision specifies the
        /// number of digits in the GEOREF string for yLat and xLon:
        ///                                 0 for nearest degree
        ///                                 1 for nearest ten minutes
        ///                                 2 for nearest minute
        ///                                 3 for nearest tenth of a minute
        ///                                 4 for nearest hundredth of a minute
        ///                                 5 for nearest thousandth of a minute
        /// </summary>
        /// <param name="xLon">Longitude in radians.</param>
        /// <param name="yLat">Latitude in radians.</param>
        /// <param name="zAlt">Height in meters.</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        /// <remarks>
        /// NOTE: This (default) variation makes the call with a default precision of MAX_PRECISION.
        /// </remarks>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            return FromGeodetic(xLon, yLat, zAlt, MAX_PRECISION);
        }

        #endregion
    }
}


