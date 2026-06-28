// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Formatting;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// A single geodetic point, exposing both decimal-degree and degrees-minutes-seconds
    /// representations of its longitude and latitude.
    /// </summary>
    public class GeoPoint : IGeoPoint, ICloneable
    {
        #region Private Member Variables

        private double _yLat;
        private double _xLon;
        private IDmsFormatter _dmsFormatter = DmsFormatterFactory.Create(DmsFormat.Default);

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the latitude, in decimal degrees (DD format).
        /// </summary>
        public double yLat
        {
            get { return _yLat; }
            set { _yLat = value; }
        }

        /// <summary>
        /// Gets or sets the longitude, in decimal degrees (DD format).
        /// </summary>
        public double xLon
        {
            get { return _xLon; }
            set { _xLon = value; }
        }

        /// <summary>
        /// Gets or sets the latitude as a degrees-minutes-seconds formatted string.
        /// </summary>
        public string yLatDms
        {
            get { return _dmsFormatter.DdToDmsNs(_yLat); }
            set { _yLat = _dmsFormatter.DmsToDdNs(value); }
        }

        /// <summary>
        /// Gets or sets the longitude as a degrees-minutes-seconds formatted string.
        /// </summary>
        public string xLonDms
        {
            get { return _dmsFormatter.DdToDmsEw(_xLon); }
            set { _xLon = _dmsFormatter.DmsToDdEw(value); }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new instance of the GeoPoint class at (0, 0).
        /// </summary>
        public GeoPoint() : this(0, 0) { }

        /// <summary>
        /// Initializes a new instance of the GeoPoint class at the specified longitude and latitude.
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        public GeoPoint(double xLon, double yLat)
        {
            _yLat = yLat;
            _xLon = xLon;
        }

        /// <summary>
        /// Initializes a new instance of the GeoPoint class as a copy of another.
        /// </summary>
        /// <param name="other">The GeoPoint to copy.</param>
        public GeoPoint(GeoPoint other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a copy of this point.
        /// </summary>
        /// <returns>A new GeoPoint with the same longitude and latitude as this instance.</returns>
        public virtual object Clone()
        {
            return new GeoPoint(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type GeoPoint.</param>
        /// <exception cref="FailedItemCopyException">Thrown if value is null, is not a GeoPoint, or copying otherwise fails.</exception>
        public void ItemCopy(object value)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(value);
                GeoPoint other = (GeoPoint)value;
                this.yLat = other.yLat;
                this.xLon = other.xLon;
            }
            catch (Exception ex)
            {
                throw new FailedItemCopyException("Failed to copy item.", ex);
            }
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if obj is a GeoPoint with the same xLon and yLat as this object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is GeoPoint)) return false;
            GeoPoint other = (GeoPoint)obj;
            return this.xLon == other.xLon && this.yLat == other.yLat;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current GeoPoint.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.xLon.GetHashCode();
            result = 31 * result + this.yLat.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this GeoPoint.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        public override string ToString()
        {
            return "[GeoPoint:  x=" + this.xLon + ", y=" + this.yLat + "]";
        }

        #endregion
    }
}


