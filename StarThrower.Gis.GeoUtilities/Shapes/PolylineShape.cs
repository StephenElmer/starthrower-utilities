/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
using System.Collections.Generic;
using StarThrower.Logging;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public class PolylineShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        private List<StarThrower.Gis.GeoUtilities.Shapes.OpenPart> _partList = new List<StarThrower.Gis.GeoUtilities.Shapes.OpenPart>();


        #region Public Properties

        public int PartCount
        {
            get { return _partList.Count; }
        }

        public StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get 
            {
                double left = 180.0;
                double top = -90.0;
                double right = -180.0;
                double bottom = 90.0;
                foreach (StarThrower.Gis.GeoUtilities.Shapes.OpenPart part in _partList)
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

        public void AddPart()
        {
            _partList.Add(new StarThrower.Gis.GeoUtilities.Shapes.OpenPart());
        }

        public StarThrower.Gis.GeoUtilities.Shapes.OpenPart GetPart(int index)
        {
            return _partList[index];
        }

        public void Clear()
        {
            _partList.Clear();
        }

        #endregion


        #region Construction

        public PolylineShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polyline;
        }

        public PolylineShape(StarThrower.Gis.GeoUtilities.Shapes.PolylineShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.PolylineShape(this);
        }

        #endregion


        #region IItemCopyable Members

        public override void ItemCopy(object value)
        {
            try
            {
                if (value == null) throw new ArgumentNullException("value");
                if (!(value is StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)) throw new ArgumentException("Could not cast " + value.GetType().ToString() + " to " + this.GetType().ToString());
                StarThrower.Gis.GeoUtilities.Shapes.PolylineShape other = (StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)value;
                _partList.Clear();
                foreach (StarThrower.Gis.GeoUtilities.Shapes.OpenPart part in other._partList)
                {
                    _partList.Add((OpenPart)(part.Clone()));
                }
                base.ItemCopy(other);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".ItemCopy(object)", ex); 
                throw ex;
            }
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)) return false;
            StarThrower.Gis.GeoUtilities.Shapes.PolylineShape other = (StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)obj;
            if (_partList.Count != other._partList.Count) return false;
            for (int i = 0; i < _partList.Count; i++)
            {
                if (!(_partList[i].Equals(other._partList[i]))) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int result = 17;
            for (int i = 0; i < _partList.Count; i++)
            {
                result = 31 * result + _partList[i].GetHashCode();
            }
            return result;
        }

        public override string ToString()
        {
            return "[" + this.GetType().Name + "]";
        }

        #endregion
    }
}
