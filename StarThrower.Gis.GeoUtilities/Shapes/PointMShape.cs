// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// A single point with a measure value. Corresponds to <see cref="ShapeType.PointM"/>.
    /// </summary>
    /// <remarks>
    /// This class does not currently store an x/y coordinate or a measure value; it carries
    /// only its <see cref="Shapes.Shape.ShapeType"/>.
    /// </remarks>
    public class PointMShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of <see cref="PointMShape"/>.
        /// </summary>
        public PointMShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointM;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PointMShape"/> as a copy of another instance.
        /// </summary>
        /// <param name="other">The instance to copy.</param>
        public PointMShape(StarThrower.Gis.GeoUtilities.Shapes.PointMShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this shape.
        /// </summary>
        /// <returns>A new <see cref="PointMShape"/> that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.PointMShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type PointMShape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            PointMShape other = (PointMShape)value;

            base.ItemCopy(other);
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if <paramref name="obj"/> is a <see cref="PointMShape"/>; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.PointMShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.PointMShape other = (StarThrower.Gis.GeoUtilities.Shapes.PointMShape)obj;
            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current PointMShape.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result;
            return result;
        }

        /// <summary>
        /// Returns the string representation of this PointMShape.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        public override string ToString()
        {
            return "[" + this.GetType().Name + "]";
        }

        #endregion
    }
}


