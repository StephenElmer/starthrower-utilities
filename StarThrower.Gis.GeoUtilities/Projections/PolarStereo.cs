// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace StarThrower.Gis.GeoUtilities.Projections
{
    /// <summary>
    /// The Polar Stereographic map projection: an azimuthal projection centered on a pole,
    /// parameterized by a latitude of true scale, a longitude measured down from the pole, and
    /// false easting/northing.
    /// </summary>
    public class PolarStereo : IProjection
    {
        /// <summary>
        /// Validates that the given array of parameters matches the names and order required
        /// by the <see cref="PolarStereo"/> projection.
        /// </summary>
        /// <param name="parameters">The parameters to validate.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="parameters"/> is non-null, has exactly 4
        /// elements, and the elements are named, in order, "False_Easting", "False_Northing",
        /// "Latitude_of_True_Scale", and "Longitude_Down_From_Pole"; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool ValidateParameters(ProjectionParameter[] parameters)
        {
            if (parameters == null) return false;
            if (parameters.Length != 4) return false;
            if (!parameters[0].Name.Equals("False_Easting", StringComparison.Ordinal)) return false;
            if (!parameters[1].Name.Equals("False_Northing", StringComparison.Ordinal)) return false;
            if (!parameters[2].Name.Equals("Latitude_of_True_Scale", StringComparison.Ordinal)) return false;
            if (!parameters[3].Name.Equals("Longitude_Down_From_Pole", StringComparison.Ordinal)) return false;
            return true;
        }


        #region Private Instance Variables

        private double _falseEasting;
        private double _falseNorthing;
        private double _latitudeOfTrueScale;
        private double _longitudeDownFromPole;

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
        /// Gets the Latitude_of_True_Scale parameter value.
        /// </summary>
        public double LatitudeOfTrueScale
        {
            get { return _latitudeOfTrueScale; }
        }

        /// <summary>
        /// Gets the Longitude_Down_From_Pole parameter value.
        /// </summary>
        public double LongitudeDownFromPole
        {
            get { return _longitudeDownFromPole; }
        }

        /// <summary>
        /// Gets the value of the named projection parameter (e.g. "False_Easting", "Latitude_of_True_Scale").
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
                    case "Latitude_of_True_Scale":
                        return _latitudeOfTrueScale;
                    case "Longitude_Down_From_Pole":
                        return _longitudeDownFromPole;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(parameterName));
                }
            }
        }

        #endregion


        #region Construction

        internal PolarStereo(ProjectionParameter[] parameters)
        {
            if (!ValidateParameters(parameters)) throw new ArgumentException("invalid parameters", nameof(parameters));
            _falseEasting = parameters[0].Value;
            _falseNorthing = parameters[1].Value;
            _latitudeOfTrueScale = parameters[2].Value;
            _longitudeDownFromPole = parameters[3].Value;
        }

        internal PolarStereo(double falseEasting, double falseNorthing, double latitudeOfTrueScale, double longitudeDownFromPole)
        {
            _falseEasting = falseEasting;
            _falseNorthing = falseNorthing;
            _latitudeOfTrueScale = latitudeOfTrueScale;
            _longitudeDownFromPole = longitudeDownFromPole;
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
            result.AppendLine("<parameter name=\"Latitude_of_True_Scale\" value=\"" + _latitudeOfTrueScale.ToString(CultureInfo.InvariantCulture) + "\"/>");
            result.AppendLine("<parameter name=\"Longitude_Down_From_Pole\" value=\"" + _longitudeDownFromPole.ToString(CultureInfo.InvariantCulture) + "\"/>");
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
            if (!(obj is PolarStereo)) return false;
            PolarStereo other = (PolarStereo)obj;
            return _falseEasting.Equals(other._falseEasting) &&
                   _falseNorthing.Equals(other._falseNorthing) &&
                   _latitudeOfTrueScale.Equals(other._latitudeOfTrueScale) &&
                   _longitudeDownFromPole.Equals(other._longitudeDownFromPole);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current PolarStereo Projection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _falseEasting.GetHashCode();
            result = 31 * result + _falseNorthing.GetHashCode();
            result = 31 * result + _latitudeOfTrueScale.GetHashCode();
            result = 31 * result + _longitudeDownFromPole.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this PolarStereo Projection.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  FalseEasting=" + _falseEasting.ToString(CultureInfo.InvariantCulture) + ", FalseNorthing=" + _falseNorthing.ToString(CultureInfo.InvariantCulture) + ", LatitudeOfTrueScale=" + _latitudeOfTrueScale.ToString(CultureInfo.InvariantCulture) + ", LongitudeDownFromPole=" + _longitudeDownFromPole.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}


