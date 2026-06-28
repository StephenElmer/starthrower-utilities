// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    /// <summary>
    /// The Local Cartesian projection: a local tangent-plane projection centered on an origin
    /// point, parameterized by the origin's latitude, longitude, and height, plus an orientation angle.
    /// </summary>
    public class LocalCartesian : IProjection
    {
        /// <summary>
        /// Validates that the given array of parameters matches the names and order required
        /// by the <see cref="LocalCartesian"/> projection.
        /// </summary>
        /// <param name="parameters">The parameters to validate.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="parameters"/> is non-null, has exactly 4
        /// elements, and the elements are named, in order, "Latitude_of_Origin",
        /// "Longitude_of_Origin", "Origin_Height", and "Orientation"; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            if (parameters == null) return false;
            if (parameters.Length != 4) return false;
            if (!parameters[0].Name.Equals("Latitude_of_Origin", StringComparison.Ordinal)) return false;
            if (!parameters[1].Name.Equals("Longitude_of_Origin", StringComparison.Ordinal)) return false;
            if (!parameters[2].Name.Equals("Origin_Height", StringComparison.Ordinal)) return false;
            if (!parameters[3].Name.Equals("Orientation", StringComparison.Ordinal)) return false;
            return true;
        }


        #region Private Instance Variables

        private double _latitudeOfOrigin;
        private double _longitudeOfOrigin;
        private double _originHeight;
        private double _orientation;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the Latitude_of_Origin parameter value.
        /// </summary>
        public double LatitudeOfOrigin
        {
            get { return _latitudeOfOrigin; }
        }

        /// <summary>
        /// Gets the Longitude_of_Origin parameter value.
        /// </summary>
        public double LongitudeOfOrigin
        {
            get { return _longitudeOfOrigin; }
        }

        /// <summary>
        /// Gets the Origin_Height parameter value.
        /// </summary>
        public double OriginHeight
        {
            get { return _originHeight; }
        }

        /// <summary>
        /// Gets the Orientation parameter value.
        /// </summary>
        public double Orientation
        {
            get { return _orientation; }
        }

        /// <summary>
        /// Gets the value of the named projection parameter (e.g. "Latitude_of_Origin", "Orientation").
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
                    case "Latitude_of_Origin":
                        return _latitudeOfOrigin;
                    case "Longitude_of_Origin":
                        return _longitudeOfOrigin;
                    case "Origin_Height":
                        return _originHeight;
                    case "Orientation":
                        return _orientation;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(parameterName));
                }
            }
        }

        #endregion


        #region Construction

        internal LocalCartesian(ProjectionParameter[] parameters)
        {
            if (!ValidateParameters(parameters)) throw new ArgumentException("invalid parameters", nameof(parameters));
            _latitudeOfOrigin = parameters[0].Value;
            _longitudeOfOrigin = parameters[1].Value;
            _originHeight = parameters[2].Value;
            _orientation = parameters[3].Value;
        }

        internal LocalCartesian(double latitudeOfOrigin, double longitudeOfOrigin, double originHeight, double orientation)
        {
            _latitudeOfOrigin = latitudeOfOrigin;
            _longitudeOfOrigin = longitudeOfOrigin;
            _originHeight = originHeight;
            _orientation = orientation;
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
            result.AppendLine("<parameter name=\"Latitude_of_Origin\" value=\"" + _latitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Longitude_of_Origin\" value=\"" + _longitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Origin_Height\" value=\"" + _originHeight.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Orientation\" value=\"" + _orientation.ToString(CultureInfo.InvariantCulture) + "\"/>");
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
            if (!(obj is LocalCartesian)) return false;
            LocalCartesian other = (LocalCartesian)obj;
            return _latitudeOfOrigin.Equals(other._latitudeOfOrigin) &&
                   _longitudeOfOrigin.Equals(other._longitudeOfOrigin) &&
                   _originHeight.Equals(other._originHeight) &&
                   _orientation.Equals(other._orientation);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current LocalCartestan Projection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _latitudeOfOrigin.GetHashCode();
            result = 31 * result + _longitudeOfOrigin.GetHashCode();
            result = 31 * result + _originHeight.GetHashCode();
            result = 31 * result + _orientation.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this LocalCartesian Projection.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  LatitudeOfOrigin=" + _latitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + ", LongitudeOfOrigin=" + _longitudeOfOrigin.ToString(CultureInfo.InvariantCulture) + ", OriginHeight=" + _originHeight.ToString(CultureInfo.InvariantCulture) + ", Orientation=" + _orientation.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


