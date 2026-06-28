// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    /// <summary>
    /// The Eckert IV map projection: a pseudocylindrical, equal-area projection parameterized
    /// by a latitude of origin, central meridian, and false easting/northing.
    /// </summary>
    public class Eckert4 : IProjection
    {
        /// <summary>
        /// Validates that the given array of parameters matches the names and order required
        /// by the <see cref="Eckert4"/> projection.
        /// </summary>
        /// <param name="parameters">The parameters to validate.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="parameters"/> is non-null, has exactly 4
        /// elements, and the elements are named, in order, "False_Easting", "False_Northing",
        /// "Central_Meridian", and "Latitude_of_Origin"; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            if (parameters == null) return false;
            if (parameters.Length != 4) return false;
            if (!parameters[0].Name.Equals("False_Easting", StringComparison.Ordinal)) return false;
            if (!parameters[1].Name.Equals("False_Northing", StringComparison.Ordinal)) return false;
            if (!parameters[2].Name.Equals("Central_Meridian", StringComparison.Ordinal)) return false;
            if (!parameters[3].Name.Equals("Latitude_of_Origin", StringComparison.Ordinal)) return false;
            return true;
        }


        #region Private Instance Variables

        private double _falseEasting;
        private double _falseNorthing;
        private double _centralMeridian;
        private double _latitudeOfOrigin;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the False_Easting parameter value.
        /// </summary>
        public double FalseEasting
        {
            get { return _falseEasting; }
        }

        /// <summary>
        /// Gets the False_Northing parameter value.
        /// </summary>
        public double FalseNorthing
        {
            get { return _falseNorthing; }
        }

        /// <summary>
        /// Gets the Central_Meridian parameter value.
        /// </summary>
        public double CentralMeridian
        {
            get { return _centralMeridian; }
        }

        /// <summary>
        /// Gets the Latitude_of_Origin parameter value.
        /// </summary>
        public double LatitudeOfOrigin
        {
            get { return _latitudeOfOrigin; }
        }

        /// <summary>
        /// Gets the value of the named projection parameter (e.g. "False_Easting", "Central_Meridian").
        /// </summary>
        /// <param name="parameterName">The name of the projection parameter to retrieve.</param>
        /// <returns>The value of the named parameter.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="parameterName"/> is not a recognized parameter name.</exception>
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
                    case "Latitude_of_Origin":
                        return _latitudeOfOrigin;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(parameterName));
                }
            }
        }

        #endregion


        #region Construction

        internal Eckert4(ProjectionParameter[] parameters)
        {
            if (!ValidateParameters(parameters)) throw new ArgumentException("invalid parameters", nameof(parameters));
            _falseEasting = parameters[0].Value;
            _falseNorthing = parameters[1].Value;
            _centralMeridian = parameters[2].Value;
            _latitudeOfOrigin = parameters[3].Value;
        }

        internal Eckert4(double falseEasting, double falseNorthing, double centralMeridian, double latitudeOfOrigin)
        {
            _falseEasting = falseEasting;
            _falseNorthing = falseNorthing;
            _centralMeridian = centralMeridian;
            _latitudeOfOrigin = latitudeOfOrigin;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the projection and its parameters.
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        public string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<projection projectionType=\"" + this.GetType().Name + "\">");
            result.AppendLine("<parameter name=\"False_Easting\" value=\"" + _falseEasting.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"False_Northing\" value=\"" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Central_Meridian\" value=\"" + _centralMeridian.ToString(CultureInfo.InvariantCulture) + "\"/>");
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
            if (!(obj is Eckert4)) return false;
            Eckert4 other = (Eckert4)obj;
            return _falseEasting.Equals(other._falseEasting) &&
                   _falseNorthing.Equals(other._falseNorthing) &&
                   _centralMeridian.Equals(other._centralMeridian) &&
                   _latitudeOfOrigin.Equals(other._latitudeOfOrigin);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Eckert4 Projection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _falseEasting.GetHashCode();
            result = 31 * result + _falseNorthing.GetHashCode();
            result = 31 * result + _centralMeridian.GetHashCode();
            result = 31 * result + _latitudeOfOrigin.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this Eckert4 Projection.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  FalseEasting=" + _falseEasting.ToString(CultureInfo.InvariantCulture) + ", FalseNorthing=" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + ", CentralMeridian=" + _centralMeridian.ToString(CultureInfo.InvariantCulture) + ", LatitudeOfOrigin=" + _latitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


