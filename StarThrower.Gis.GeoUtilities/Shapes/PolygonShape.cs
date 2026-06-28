// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// One or more rings forming a polygon. Corresponds to <see cref="ShapeType.Polygon"/>.
    /// </summary>
    public class PolygonShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        private List<StarThrower.Gis.GeoUtilities.Shapes.ClosedPart> _partList = new List<StarThrower.Gis.GeoUtilities.Shapes.ClosedPart>();


        #region Public Properties

        /// <summary>
        /// Gets the number of parts (rings) in this polygon.
        /// </summary>
        public int PartCount
        {
            get { return _partList.Count; }
        }

        /// <summary>
        /// Gets the bounding rectangle that encloses all parts of this polygon.
        /// </summary>
        /// <remarks>
        /// The setter is a no-op; <see cref="Extent"/> is always computed from the current parts.
        /// </remarks>
        public StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                double left = 180.0;
                double top = -90.0;
                double right = -180.0;
                double bottom = 90.0;
                foreach (StarThrower.Gis.GeoUtilities.Shapes.ClosedPart part in _partList)
                {
                    StarThrower.Gis.GeoUtilities.GeoRectangle extent = part.Extent;
                    if (extent.Left < left) left = extent.Left;
                    if (extent.Top > top) top = extent.Top;
                    if (extent.Right > right) right = extent.Right;
                    if (extent.Bottom < bottom) bottom = extent.Bottom;
                }
                return new StarThrower.Gis.GeoUtilities.GeoRectangle(left, top, right, bottom);
            }
            set { }
        }

        /// <summary>
        /// Gets the total number of points across all parts of this polygon.
        /// </summary>
        public int PointCount
        {
            get { return GetPointCount(); }
        }

        #endregion


        #region Private Methods

        private int GetPointCount()
        {
            int result = 0;

            for (int i = 0; i < _partList.Count; i++)
            {
                result += _partList[i].PointCount;
            }

            return result;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Appends a new, empty <see cref="ClosedPart"/> to this polygon.
        /// </summary>
        public void AddPart()
        {
            _partList.Add(new StarThrower.Gis.GeoUtilities.Shapes.ClosedPart());
        }

        /// <summary>
        /// Gets the part at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the part to retrieve.</param>
        /// <returns>The <see cref="ClosedPart"/> at <paramref name="index"/>.</returns>
        public StarThrower.Gis.GeoUtilities.Shapes.ClosedPart GetPart(int index)
        {
            return _partList[index];
        }

        /// <summary>
        /// Removes all parts from this polygon.
        /// </summary>
        public void Clear()
        {
            _partList.Clear();
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, empty instance of <see cref="PolygonShape"/>.
        /// </summary>
        public PolygonShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polygon;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PolygonShape"/> as a copy of another instance.
        /// </summary>
        /// <param name="other">The instance to copy.</param>
        public PolygonShape(StarThrower.Gis.GeoUtilities.Shapes.PolygonShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this shape.
        /// </summary>
        /// <returns>A new <see cref="PolygonShape"/> that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.PolygonShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">The instance you wish this to be a copy of. Must be a <see cref="PolygonShape"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a <see cref="PolygonShape"/>.</exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (!(value is StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)) throw new ArgumentException("Could not cast " + value.GetType().ToString() + " to " + this.GetType().ToString());
            StarThrower.Gis.GeoUtilities.Shapes.PolygonShape other = (StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)value;
            _partList.Clear();
            foreach (StarThrower.Gis.GeoUtilities.Shapes.ClosedPart part in other._partList)
            {
                _partList.Add((ClosedPart)(part.Clone()));
            }
            base.ItemCopy(other);
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if <paramref name="obj"/> is a <see cref="PolygonShape"/> with the same parts, in the same order; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.PolygonShape other = (StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)obj;
            if (_partList.Count != other._partList.Count) return false;
            for (int i = 0; i < _partList.Count; i++)
            {
                if (!(_partList[i].Equals(other._partList[i]))) return false;
            }
            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current PolygonShape.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            for (int i = 0; i < _partList.Count; i++)
            {
                result = 31 * result + _partList[i].GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Returns the string representation of this PolygonShape.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        public override string ToString()
        {
            return "[" + this.GetType().Name + "]";
        }

        #endregion
    }
}


