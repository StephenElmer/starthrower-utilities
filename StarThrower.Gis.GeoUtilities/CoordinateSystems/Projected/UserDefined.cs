// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// Provides the ability to create user defined Projected Coordinate Systems
    /// </summary>
    public class UserDefined : ProjectedCoordinateSystem
    {
        #region Private Instance Variables

        private string _name;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the unique name of this UserDefined projected coordinate system.
        /// </summary>
        public override string Name
        {
            get { return _name; }
        }

        #endregion


        #region Construction

        internal UserDefined(string name, IGeographicCoordinateSystem geographicCoordinateSystem, IProjection projection, ILinearUnit linearUnit) : base()
        {
            ArgumentNullException.ThrowIfNull(name);
            if (!StringUtil.IsValid(name, ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            _name = name;

            this.GeographicCoordinateSystem = geographicCoordinateSystem;
            this.Projection = projection;
            this.LinearUnit = linearUnit;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets an XML representation of the ProjectedCoordinateSystem.
        /// </summary>
        /// <returns>The xml representation of the ProjectedCoordinateSystem.</returns>
        public override string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.Append("<projectedCoordinateSystem projectedCoordinateSystemType=\"" + this.GetType().Name + "\" name=\"" + _name + "\">\n");
            result.Append(this.GeographicCoordinateSystem.ToXml());
            result.Append(this.Projection.ToXml());
            result.Append(this.LinearUnit.ToXml());
            result.Append("</projectedCoordinateSystem>\n");

            return result.ToString();
        }

        /// <summary>
        /// Not yet implemented: this override does not convert this UserDefined system's projected
        /// (easting/northing) coordinates to geodetic coordinates. It returns the input values unchanged.
        /// </summary>
        /// <param name="xLon">The x (easting) coordinate.</param>
        /// <param name="yLat">The y (northing) coordinate.</param>
        /// <param name="zAlt">The vertical (height/altitude) coordinate.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> wrapping the unconverted input coordinate.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Not yet implemented: this override does not convert geodetic coordinates to this
        /// UserDefined system's projected (easting/northing) coordinates. It returns the input
        /// values unchanged.
        /// </summary>
        /// <param name="xLon">The longitude.</param>
        /// <param name="yLat">The latitude.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> wrapping the unconverted input coordinate.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
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
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            UserDefined other = (UserDefined)obj;
            return this.GeographicCoordinateSystem.Equals(other.GeographicCoordinateSystem) &&
                   this.Projection.Equals(other.Projection) &&
                   this.LinearUnit.Equals(other.LinearUnit) &&
                   _name.Equals(other._name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current ProjectedCoordinateSystem.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.GeographicCoordinateSystem.GetHashCode();
            result = 31 * result + this.Projection.GetHashCode();
            result = 31 * result + this.LinearUnit.GetHashCode();
            result = 31 * result + _name.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this ProjectedCoordinateSystem.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', GeographicCoordinateSystem=" + this.GeographicCoordinateSystem.GetType().Name + ", Projection=" + this.Projection.GetType().Name + ", LinearUnit=" + this.LinearUnit.GetType().Name + "]";
        }

        #endregion
    }
}


