// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public class PolygonShape : StarThrower.Gis.GeoUtilities.Shapes.Shape, ICloneable
    {
        private List<StarThrower.Gis.GeoUtilities.Shapes.ClosedPart> _partList = new List<StarThrower.Gis.GeoUtilities.Shapes.ClosedPart>();


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
            _partList.Add(new StarThrower.Gis.GeoUtilities.Shapes.ClosedPart());
        }

        public StarThrower.Gis.GeoUtilities.Shapes.ClosedPart GetPart(int index)
        {
            return _partList[index];
        }

        public void Clear()
        {
            _partList.Clear();
        }

        #endregion


        #region Construction

        public PolygonShape() : base()
        {
            this.ShapeType = StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polygon;
        }

        public PolygonShape(StarThrower.Gis.GeoUtilities.Shapes.PolygonShape other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.PolygonShape(this);
        }

        #endregion


        #region IItemCopyable Members

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


