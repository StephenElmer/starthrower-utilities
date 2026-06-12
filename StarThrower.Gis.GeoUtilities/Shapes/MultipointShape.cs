// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public class MultipointShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        #region Construction

        public MultipointShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipoint;
        }

        public MultipointShape(StarThrower.Gis.GeoUtilities.Shapes.MultipointShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.MultipointShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type MultiPointShape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            MultipointShape other = (MultipointShape)value;

            base.ItemCopy(other);
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.MultipointShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.MultipointShape other = (StarThrower.Gis.GeoUtilities.Shapes.MultipointShape)obj;
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


