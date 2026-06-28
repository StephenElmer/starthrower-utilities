// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems
{
    /// <summary>
    /// Base class for a geographic (latitude/longitude) coordinate system tied to a datum,
    /// prime meridian, and angular unit.
    /// </summary>
    public abstract class GeographicCoordinateSystem : IGeographicCoordinateSystem
    {
        /// <summary>
        /// The regular expression pattern to which the Ellipsoid's Name field must match.
        /// </summary>
        public const string ValidNamePattern = @"^[a-zA-Z_0-9]+$";


        #region Private Instance Variables

        private long _significantDigits;
        private IDatum _datum = null!; // always set by derived class constructor
        private IPrimeMeridian _primeMeridian = null!; // always set by derived class constructor
        private IAngularUnit _angularUnit = null!; // always set by derived class constructor

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the SignificantDigits of the CoordinateSystem
        /// </summary>
        public long SignificantDigits
        {
            get { return _significantDigits; }
            protected set { _significantDigits = value; }
        }

        /// <summary>
        /// Gets the Datum of the GeographicCoordinateSystem
        /// </summary>
        public IDatum Datum
        {
            get { return _datum; }
            protected set { _datum = value; }
        }

        /// <summary>
        /// Gets the PrimeMeridian of the GeographicCoordinateSystem
        /// </summary>
        public IPrimeMeridian PrimeMeridian
        {
            get { return _primeMeridian; }
            protected set { _primeMeridian = value; }
        }

        /// <summary>
        /// Gets the AngularUnit of the GeographicCoordinateSystem
        /// </summary>
        public IAngularUnit AngularUnit
        {
            get { return _angularUnit; }
            protected set { _angularUnit = value; }
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
        public string Key
        {
            get
            {
                if (this is StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic.UserDefined)
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
        /// Initializes a new geographic coordinate system with 7 significant digits (sufficient
        /// to resolve to centimeters).
        /// </summary>
        protected GeographicCoordinateSystem()
        {
            _significantDigits = 7; // 7 significant digits gets us to Centimeters
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Converts a coordinate expressed in this coordinate system to geodetic
        /// (latitude/longitude/height) coordinates.
        /// </summary>
        /// <param name="xLon">The longitude.</param>
        /// <param name="yLat">The latitude.</param>
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
        /// Gets the XML representation of the GeographicCoordinateSystem
        /// </summary>
        /// <returns>An XML formatted string.</returns>
        public virtual string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.Append("<geographicCoordinateSystem geographicCoordinateSystemType=\"" + this.GetType().Name + "\">\n");
            result.Append(_datum.ToXml());
            result.Append(_primeMeridian.ToXml());
            result.Append(_angularUnit.ToXml());
            result.Append("</geographicCoordinateSystem>\n");

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
            GeographicCoordinateSystem other = (GeographicCoordinateSystem)obj;
            return _datum.Equals(other._datum) &&
                   _primeMeridian.Equals(other._primeMeridian) &&
                   _angularUnit.Equals(other._angularUnit);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current GeographicCoordinateSystem.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _datum.GetHashCode();
            result = 31 * result + _primeMeridian.GetHashCode();
            result = 31 * result + _angularUnit.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this GeographicCoordinateSystem.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Datum=" + _datum.GetType().Name + ", PrimeMeridian=" + _primeMeridian.GetType().Name + "]";
        }

        #endregion
    }
}


