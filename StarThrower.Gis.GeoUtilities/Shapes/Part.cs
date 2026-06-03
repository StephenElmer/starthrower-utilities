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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StarThrower.Logging;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public abstract class Part : ICloneable
    {
        #region Private Instance Variables

        private Collection<StarThrower.Gis.GeoUtilities.Shapes.PointShape> _pointList = new Collection<StarThrower.Gis.GeoUtilities.Shapes.PointShape>();

        #endregion


        #region Public Properties

        protected Collection<StarThrower.Gis.GeoUtilities.Shapes.PointShape> PointList
        {
            get { return _pointList; }
        }

        public int PointCount
        {
            get { return _pointList.Count; }
        }

        #endregion


        #region Internal Properties

        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                if (_pointList.Count == 0) return new StarThrower.Gis.GeoUtilities.GeoRectangle(0.0, 0.0, 0.0, 0.0);
                double left = 180.0;
                double top = -90.0;
                double right = -180.0;
                double bottom = 90.0;
                foreach (StarThrower.Gis.GeoUtilities.Shapes.PointShape point in _pointList)
                {
                    if (point.xLon < left) left = point.xLon;
                    if (point.yLat > top) top = point.yLat;
                    if (point.xLon > right) right = point.xLon;
                    if (point.yLat < bottom) bottom = point.yLat;
                }
                return new StarThrower.Gis.GeoUtilities.GeoRectangle(left, top, right, bottom);
            }
        }

        #endregion


        #region Public Methods

        public void AddPoint(StarThrower.Gis.GeoUtilities.Shapes.PointShape point)
        {
            _pointList.Add(point);
        }

        public StarThrower.Gis.GeoUtilities.Shapes.PointShape GetPoint(int index)
        {
            return _pointList[index];
        }

        #endregion


        #region ICloneable Members

        public abstract object Clone();

        #endregion


        #region IItemCopyable Members

        public virtual void ItemCopy(object value)
        {
            try
            {
                if (value == null) throw new ArgumentNullException("value");
                if (!(value is StarThrower.Gis.GeoUtilities.Shapes.Part)) throw new ArgumentException("Could not cast " + value.GetType().ToString() + " to " + this.GetType().ToString());
                StarThrower.Gis.GeoUtilities.Shapes.Part other = (StarThrower.Gis.GeoUtilities.Shapes.Part)value;
                _pointList.Clear();
                foreach (StarThrower.Gis.GeoUtilities.Shapes.PointShape point in other._pointList)
                {
                    _pointList.Add((PointShape)(point.Clone()));
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".ItemCopy(object)", ex);
                throw;
            }
        }

        #endregion

    }
}


