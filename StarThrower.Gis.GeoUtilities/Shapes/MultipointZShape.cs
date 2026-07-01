// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// A set of points with Z (elevation) values. Corresponds to <see cref="ShapeType.MultipointZ"/>.
    /// </summary>
    /// <remarks>
    /// This class does not currently store any points or Z values; it carries only its
    /// <see cref="Shapes.Shape.ShapeType"/>.
    /// </remarks>
    public class MultipointZShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of <see cref="MultipointZShape"/>.
        /// </summary>
        public MultipointZShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointZ;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MultipointZShape"/> as a copy of another instance.
        /// </summary>
        /// <param name="other">The instance to copy.</param>
        public MultipointZShape(StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this shape.
        /// </summary>
        /// <returns>A new <see cref="MultipointZShape"/> that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type MultipointZShape.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidCastException"><paramref name="value"/> is not a <see cref="MultipointZShape"/>.</exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            MultipointZShape other = (MultipointZShape)value;

            base.ItemCopy(other);
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if <paramref name="obj"/> is a <see cref="MultipointZShape"/>; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape other = (StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape)obj;
            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current MultipointZShape.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result;
            return result;
        }

        /// <summary>
        /// Returns the string representation of this MultipointZShape.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        public override string ToString()
        {
            return "[" + this.GetType().Name + "]";
        }

        #endregion
    }
}


