// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// A single point. Corresponds to <see cref="ShapeType.Point"/>.
    /// </summary>
    public class PointShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, StarThrower.Gis.GeoUtilities.IGeoPoint, ICloneable
    {
        private StarThrower.Gis.GeoUtilities.GeoPoint _point;


        #region Public Properties

        /// <summary>
        /// Gets or sets the x (longitude) coordinate, in decimal degrees.
        /// </summary>
        public double xLon
        {
            get { return _point.xLon; }
            set { _point.xLon = value; }
        }

        /// <summary>
        /// Gets or sets the y (latitude) coordinate, in decimal degrees.
        /// </summary>
        public double yLat
        {
            get { return _point.yLat; }
            set { _point.yLat = value; }
        }

        /// <summary>
        /// Gets or sets the x (longitude) coordinate, formatted as degrees-minutes-seconds.
        /// </summary>
        public string xLonDms
        {
            get { return _point.xLonDms; }
            set { _point.xLonDms = value; }
        }

        /// <summary>
        /// Gets or sets the y (latitude) coordinate, formatted as degrees-minutes-seconds.
        /// </summary>
        public string yLatDms
        {
            get { return _point.yLatDms; }
            set { _point.yLatDms = value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new instance of <see cref="PointShape"/> at the origin (0, 0).
        /// </summary>
        public PointShape() : this(0, 0) { }

        /// <summary>
        /// Initializes a new instance of <see cref="PointShape"/> at the given coordinate.
        /// </summary>
        /// <param name="xLon">The x (longitude) coordinate, in decimal degrees.</param>
        /// <param name="yLat">The y (latitude) coordinate, in decimal degrees.</param>
        public PointShape(double xLon, double yLat) : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Point;
            _point = new StarThrower.Gis.GeoUtilities.GeoPoint(xLon, yLat);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PointShape"/> as a copy of another instance.
        /// </summary>
        /// <param name="other">The instance to copy.</param>
        public PointShape(StarThrower.Gis.GeoUtilities.Shapes.PointShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this shape.
        /// </summary>
        /// <returns>A new <see cref="PointShape"/> that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.PointShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type PointShape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            PointShape other = (PointShape)value;

            this.xLon = other.xLon;
            this.yLat = other.yLat;
            base.ItemCopy(other);
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if <paramref name="obj"/> is a <see cref="PointShape"/> with the same coordinate; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.PointShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.PointShape other = (StarThrower.Gis.GeoUtilities.Shapes.PointShape)obj;
            return this.xLon == other.xLon && this.yLat == other.yLat;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current PointShape.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.xLon.GetHashCode();
            result = 31 * result + this.yLat.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this PointShape.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  x=" + this.xLon +", y=" + this.yLat + "]";
        }

        #endregion
    }
}


