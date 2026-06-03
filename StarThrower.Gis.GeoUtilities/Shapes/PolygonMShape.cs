/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using StarThrower.Logging;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public class PolygonMShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        #region Construction

        public PolygonMShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonM;
        }

        public PolygonMShape(StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type PolygonMShape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            try
            {
                if (value == null) throw new ArgumentNullException("value");
                PolygonMShape other = (PolygonMShape)value;

                base.ItemCopy(other);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".ItemCopy(object)", ex);
                throw;
            }
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape other = (StarThrower.Gis.GeoUtilities.Shapes.PolygonMShape)obj;
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


