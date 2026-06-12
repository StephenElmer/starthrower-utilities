// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public class MultipointZShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        #region Construction

        public MultipointZShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointZ;
        }

        public MultipointZShape(StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type MultiPointZShape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            MultipointZShape other = (MultipointZShape)value;

            base.ItemCopy(other);
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape other = (StarThrower.Gis.GeoUtilities.Shapes.MultipointZShape)obj;
            return true;
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result;
            return result;
        }

        public override string ToString()
        {
            return "[" + this.GetType().Name + "]";
        }

        #endregion
    }
}


