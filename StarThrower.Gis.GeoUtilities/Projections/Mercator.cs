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
using System.Text;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    public class Mercator : IProjection
    {
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            if (parameters == null) return false;
            if (parameters.Length != 5) return false;
            if (!parameters[0].Name.Equals("False_Easting", StringComparison.Ordinal)) return false;
            if (!parameters[1].Name.Equals("False_Northing", StringComparison.Ordinal)) return false;
            if (!parameters[2].Name.Equals("Central_Meridian", StringComparison.Ordinal)) return false;
            if (!parameters[3].Name.Equals("Scale_Factor", StringComparison.Ordinal)) return false;
            if (!parameters[4].Name.Equals("Latitude_of_Origin", StringComparison.Ordinal)) return false;
            return true;
        }


        #region Private Instance Variables

        private double _falseEasting;
        private double _falseNorthing;
        private double _centralMeridian;
        private double _scaleFactor;
        private double _latitudeOfOrigin;

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

        public double CentralMeridian
        {
            get { return _centralMeridian; }
        }

        public double ScaleFactor
        {
            get { return _scaleFactor; }
        }

        public double LatitudeOfOrigin
        {
            get { return _latitudeOfOrigin; }
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
                    case "Central_Meridian":
                        return _centralMeridian;
                    case "Scale_Factor":
                        return _scaleFactor;
                    case "Latitude_of_Origin":
                        return _latitudeOfOrigin;
                    default:
                        throw new ArgumentOutOfRangeException("parameterName");
                }
            }
        }

        #endregion


        #region Construction

        internal Mercator(ProjectionParameter[] parameters)
        {
            if (!ValidateParameters(parameters)) throw new ArgumentException("invalid parameters", "parameters");
            _falseEasting = parameters[0].Value;
            _falseNorthing = parameters[1].Value;
            _centralMeridian = parameters[2].Value;
            _scaleFactor = parameters[3].Value;
            _latitudeOfOrigin = parameters[4].Value;
        }

        internal Mercator(double falseEasting, double falseNorthing, double centralMeridian, double scaleFactor, double latitudeOfOrigin)
        {
            _falseEasting = falseEasting;
            _falseNorthing = falseNorthing;
            _centralMeridian = centralMeridian;
            _scaleFactor = scaleFactor;
            _latitudeOfOrigin = latitudeOfOrigin;
        }

        #endregion


        #region Public Methods

        public string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<projection projectionType=\"" + this.GetType().Name + "\">");
            result.AppendLine("<parameter name=\"False_Easting\" value=\"" + _falseEasting.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"False_Northing\" value=\"" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Central_Meridian\" value=\"" + _centralMeridian.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Scale_Factor\" value=\"" + _scaleFactor.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Latitude_of_Origin\" value=\"" + _latitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + "\"/>");
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
        public override bool Equals(object? obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is Mercator)) return false;
            Mercator other = (Mercator)obj;
            return _falseEasting.Equals(other._falseEasting) &&
                   _falseNorthing.Equals(other._falseNorthing) &&
                   _centralMeridian.Equals(other._centralMeridian) &&
                   _scaleFactor.Equals(other._scaleFactor) &&
                   _latitudeOfOrigin.Equals(other._latitudeOfOrigin);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current MercatorProjection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _falseEasting.GetHashCode();
            result = 31 * result + _falseNorthing.GetHashCode();
            result = 31 * result + _centralMeridian.GetHashCode();
            result = 31 * result + _scaleFactor.GetHashCode();
            result = 31 * result + _latitudeOfOrigin.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this MercatorProjection.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  FalseEasting=" + _falseEasting.ToString(CultureInfo.InvariantCulture) + ", FalseNorthing=" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + ", CentralMeridian=" + _centralMeridian.ToString(CultureInfo.InvariantCulture) + ", ScaleFactor=" + _scaleFactor.ToString(CultureInfo.InvariantCulture) + ", LatitudeOfOrigin=" + LatitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


