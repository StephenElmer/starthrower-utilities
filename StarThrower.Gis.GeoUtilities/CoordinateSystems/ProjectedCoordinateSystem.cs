// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems
{
    /// <summary>
    /// Base class for a projected (planar x/y) coordinate system, built from an underlying
    /// geographic coordinate system, a map projection, and a linear unit.
    /// </summary>
    public abstract class ProjectedCoordinateSystem : IProjectedCoordinateSystem
    {
        /// <summary>
        /// The regular expression pattern to which the ProjectedCoordinateSystem's Name field must match.
        /// </summary>
        public const string ValidNamePattern = @"^[a-zA-Z_0-9]+$";


        #region Private Instance Variables

        private long _significantDigits;
        private IGeographicCoordinateSystem _geographicCoordinateSystem = null!; // always set by derived class constructor
        private IProjection _projection = null!; // always set by derived class constructor
        private ILinearUnit _linearUnit = null!; // always set by derived class constructor

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the SignificantDigits of the CoordinateSystem
        /// </summary>
        public long SignificantDigits
        {
            get { return _significantDigits; }
        }

        /// <summary>
        /// Gets the Datum of the ProjectedCoordinateSystem.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling GeographicCoordinateSystem.Datum.
        /// </remarks>
        public IDatum Datum
        {
            get { return _geographicCoordinateSystem.Datum; }
        }

        /// <summary>
        /// Gets the PrimeMeridian of the ProjectedCoordinateSystem.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling GeographicCoordinateSystem.PrimeMeridian.
        /// </remarks>
        public IPrimeMeridian PrimeMeridian
        {
            get { return _geographicCoordinateSystem.PrimeMeridian; }
        }

        /// <summary>
        /// Gets the AngularUnit of the ProjectedCoordinateSystem.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of calling GeographicCoordinateSystem.AngularUnit.
        /// </remarks>
        public IAngularUnit AngularUnit
        {
            get { return _geographicCoordinateSystem.AngularUnit; }
        }

        /// <summary>
        /// Gets the GeographicCoordinateSystem of the ProjectedCoordinateSystem.
        /// </summary>
        public IGeographicCoordinateSystem GeographicCoordinateSystem
        {
            get { return _geographicCoordinateSystem; }
            protected set { _geographicCoordinateSystem = value; }
        }

        /// <summary>
        /// Gets the Projection of the ProjectedCoordinateSystem.
        /// </summary>
        public IProjection Projection
        {
            get { return _projection; }
            protected set { _projection = value; }
        }

        /// <summary>
        /// Gets the LinearUnit of the ProjectedCoordinateSystem.
        /// </summary>
        public ILinearUnit LinearUnit
        {
            get { return _linearUnit; }
            protected set { _linearUnit = value; }
        }

        /// <summary>
        /// Gets the value of the named projection parameter (e.g. "False_Easting", "Central_Meridian").
        /// </summary>
        /// <param name="parameterName">The name of the projection parameter to retrieve.</param>
        /// <returns>The value of the named parameter.</returns>
        public double this[string parameterName]
        {
            get
            {
                return _projection[parameterName];
            }
        }

        /// <summary>
        /// Gets the name of this coordinate system.
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the key value of this coordinate system, used to distinguish it from others
        /// (particularly user-defined coordinate systems).
        /// </summary>
        public virtual string Key
        {
            get
            {
                if (this is StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected.UserDefined)
                {
                    return this.GetType().Name + this.Name;
                }
                else
                {
                    return this.GetType().Name;
                }
            }
        }

        /// <summary>
        /// Gets how this coordinate system's vertical (height) component should be interpreted.
        /// This base implementation always returns <see cref="HeightType.NoHeight"/>.
        /// </summary>
        public virtual HeightType HeightType
        {
            get { return HeightType.NoHeight; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new projected coordinate system with 2 significant digits (sufficient
        /// to resolve to centimeters for typical projected units).
        /// </summary>
        protected ProjectedCoordinateSystem()
        {
            _significantDigits = 2; // 2 significant digits gets to Centimeters
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Converts a coordinate expressed in this coordinate system to geodetic
        /// (latitude/longitude/height) coordinates.
        /// </summary>
        /// <param name="xLon">The x (easting) coordinate.</param>
        /// <param name="yLat">The y (northing) coordinate.</param>
        /// <param name="zAlt">The vertical (height/altitude) coordinate.</param>
        /// <returns>The resulting geodetic coordinates, along with estimated accumulated error.</returns>
        public abstract ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt);

        /// <summary>
        /// Converts a geodetic (latitude/longitude/height) coordinate to this coordinate system.
        /// </summary>
        /// <param name="xLon">The longitude.</param>
        /// <param name="yLat">The latitude.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>The resulting coordinates in this coordinate system, along with estimated accumulated error.</returns>
        public abstract ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt);

        /// <summary>
        /// Gets the XML representation of the ProjectedCoordinateSystem
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        public virtual string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.Append("<projectedCoordinateSystem projectedCoordinateSystemType=\"" + this.GetType().Name + "\">\n");
            result.Append(_geographicCoordinateSystem.ToXml());
            result.Append(_projection.ToXml());
            result.Append(_linearUnit.ToXml());
            result.Append("</projectedCoordinateSystem>\n");

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
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            ProjectedCoordinateSystem other = (ProjectedCoordinateSystem)obj;
            return _geographicCoordinateSystem.Equals(other._geographicCoordinateSystem) &&
                   _projection.Equals(other._projection) &&
                   _linearUnit.Equals(other._linearUnit);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current ProjectedCoordinateSystem.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _geographicCoordinateSystem.GetHashCode();
            result = 31 * result + _projection.GetHashCode();
            result = 31 * result + _linearUnit.GetHashCode();
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
            return "[" + this.GetType().Name + ":  GeographicCoordinateSystem=" + _geographicCoordinateSystem.GetType().Name + ", Projection=" + _projection.GetType().Name + ", LinearUnit=" + _linearUnit.GetType().Name + "]";
        }

        #endregion
    }
}


