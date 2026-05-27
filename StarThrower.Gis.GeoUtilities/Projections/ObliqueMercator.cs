/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
using System.Text;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    public class ObliqueMercator : IProjection
    {
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            if (parameters == null) return false;
            if (parameters.Length != 8) return false;
            if (!parameters[0].Name.Equals("False_Easting")) return false;
            if (!parameters[1].Name.Equals("False_Northing")) return false;
            if (!parameters[2].Name.Equals("Latitude_of_Origin")) return false;
            if (!parameters[3].Name.Equals("Latitude_1")) return false;
            if (!parameters[4].Name.Equals("Longitude_1")) return false;
            if (!parameters[5].Name.Equals("Latitude_2")) return false;
            if (!parameters[6].Name.Equals("Longitude_2")) return false;
            if (!parameters[7].Name.Equals("Scale_Factor")) return false;
            return true;
        }


        #region Private Instance Variables

        private double _falseEasting;
        private double _falseNorthing;
        private double _latitudeOfOrigin;
        private double _latitude1;
        private double _longitude1;
        private double _latitude2;
        private double _longitude2;
        private double _scaleFactor;

        #endregion


        #region Public Properties

        public double FalseEasting
        {
            get { return _falseEasting; }
        }

        public double FalseNorthing
        {
            get { return _falseNorthing; }
        }

        public double LatitudeOfOrigin
        {
            get { return _latitudeOfOrigin; }
        }

        public double Latitude1
        {
            get { return _latitude1; }
        }

        public double Longitude1
        {
            get { return _longitude1; }
        }

        public double Latitude2
        {
            get { return _latitude2; }
        }

        public double Longitude2
        {
            get { return _longitude2; }
        }

        public double ScaleFactor
        {
            get { return _scaleFactor; }
        }

        public double this[string parameterName]
        {
            get
            {
                switch (parameterName)
                {
                    case "False_Easting":
                        return _falseEasting;
                    case "False_Northing":
                        return _falseNorthing;
                    case "Latitude_of_Origin":
                        return _latitudeOfOrigin;
                    case "Latitude_1":
                        return _latitude1;
                    case "Longitude_1":
                        return _longitude1;
                    case "Latitude_2":
                        return _latitude2;
                    case "Longitude_2":
                        return _longitude2;
                    case "Scale_Factor":
                        return _scaleFactor;
                    default:
                        throw new ArgumentOutOfRangeException("parameterName");
                }
            }
        }

        #endregion


        #region Construction

        internal ObliqueMercator(ProjectionParameter[] parameters)
        {
            if (!ValidateParameters(parameters)) throw new ArgumentException("invalid parameters", "parameters");
            _falseEasting = parameters[0].Value;
            _falseNorthing = parameters[1].Value;
            _latitudeOfOrigin = parameters[2].Value;
            _latitude1 = parameters[3].Value;
            _longitude1 = parameters[4].Value;
            _latitude2 = parameters[5].Value;
            _longitude2 = parameters[6].Value;
            _scaleFactor = parameters[7].Value;
        }

        internal ObliqueMercator(double falseEasting, double falseNorthing, double latitudeOfOrigin, double latitude1, double longitude1, double latitude2, double longitude2, double scaleFactor)
        {
            _falseEasting = falseEasting;
            _falseNorthing = falseNorthing;
            _latitudeOfOrigin = latitudeOfOrigin;
            _latitude1 = latitude1;
            _longitude1 = longitude1;
            _latitude2 = latitude2;
            _longitude2 = longitude2;
            _scaleFactor = scaleFactor;
        }

        #endregion


        #region Public Methods

        public string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<projection projectionType=\"" + this.GetType().Name + "\">");
            result.AppendLine("<parameter name=\"False_Easting\" value=\"" + _falseEasting.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"False_Northing\" value=\"" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Latitude_of_Origin\" value=\"" + _latitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Latitude_1\" value=\"" + _latitude1.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Longitude_1\" value=\"" + _longitude1.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Latitude_2\" value=\"" + _latitude2.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Longitude_2\" value=\"" + _longitude2.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Scale_Factor\" value=\"" + _scaleFactor.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("</projection>");
            return result.ToString();
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is ObliqueMercator)) return false;
            ObliqueMercator other = (ObliqueMercator)obj;
            return _falseEasting.Equals(other._falseEasting) &&
                   _falseNorthing.Equals(other._falseNorthing) &&
                   _latitudeOfOrigin.Equals(other._latitudeOfOrigin) &&
                   _latitude1.Equals(other._latitude1) &&
                   _longitude1.Equals(other._longitude1) &&
                   _latitude2.Equals(other._latitude2) &&
                   _longitude2.Equals(other._longitude2) &&
                   _scaleFactor.Equals(other._scaleFactor);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current ObliqueMercator Projection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _falseEasting.GetHashCode();
            result = 31 * result + _falseNorthing.GetHashCode();
            result = 31 * result + _latitudeOfOrigin.GetHashCode();
            result = 31 * result + _latitude1.GetHashCode();
            result = 31 * result + _longitude1.GetHashCode();
            result = 31 * result + _latitude2.GetHashCode();
            result = 31 * result + _longitude2.GetHashCode();
            result = 31 * result + _scaleFactor.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this ObliqueMercator Projection.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  FalseEasting=" + _falseEasting.ToString(CultureInfo.InvariantCulture) + ", FalseNorthing=" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + ", LatitudeOfOrigin=" + _latitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + ", Latitude1=" + _latitude1.ToString(CultureInfo.InvariantCulture) + ", Longitude1=" + _longitude1.ToString(CultureInfo.InvariantCulture) + ", Latitude2=" + _latitude2.ToString(CultureInfo.InvariantCulture) + ", Longitude2=" + _longitude2.ToString(CultureInfo.InvariantCulture) + ", ScaleFactor=" + _scaleFactor.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}
