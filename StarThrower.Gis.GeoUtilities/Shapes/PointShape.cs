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
    public class PointShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, StarThrower.Gis.GeoUtilities.IGeoPoint, ICloneable
    {
        private StarThrower.Gis.GeoUtilities.GeoPoint _point;


        #region Public Properties

        public double xLon
        {
            get { return _point.xLon; }
            set { _point.xLon = value; }
        }

        public double yLat
        {
            get { return _point.yLat; }
            set { _point.yLat = value; }
        }

        public string xLonDms
        {
            get { return _point.xLonDms; }
            set { _point.xLonDms = value; }
        }

        public string yLatDms
        {
            get { return _point.yLatDms; }
            set { _point.yLatDms = value; }
        }

        #endregion 


        #region Construction

        public PointShape() : this(0, 0) { }

        public PointShape(double xLon, double yLat) : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Point;
            _point = new StarThrower.Gis.GeoUtilities.GeoPoint(xLon, yLat);
        }

        public PointShape(StarThrower.Gis.GeoUtilities.Shapes.PointShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

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
            try
            {
                if (value == null) throw new ArgumentNullException("value");
                PointShape other = (PointShape)value;

                this.xLon = other.xLon;
                this.yLat = other.yLat;
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
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.PointShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.PointShape other = (StarThrower.Gis.GeoUtilities.Shapes.PointShape)obj;
            return this.xLon == other.xLon && this.yLat == other.yLat;
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + this.xLon.GetHashCode();
            result = 31 * result + this.yLat.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  x=" + this.xLon +", y=" + this.yLat + "]";
        }

        #endregion
    }
}


