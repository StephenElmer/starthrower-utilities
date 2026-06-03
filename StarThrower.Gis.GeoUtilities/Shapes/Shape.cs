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
    public enum ShapeType
    {
        NullShape = 0,
        Point = 1,
        Polyline = 3,
        Polygon = 5,
        Multipoint = 8,
        PointZ = 11,
        PolylineZ = 13,
        PolygonZ = 15,
        MultipointZ = 18,
        PointM = 21,
        PolylineM = 23,
        PolygonM = 25,
        MultipointM = 28,
        Multipatch = 31
    }

    public abstract class Shape : ICloneable
    {
        #region Private Instance Variables

        private StarThrower.Gis.GeoUtilities.Shapes.ShapeType _shapeType;

        #endregion


        #region Public Properties

        public StarThrower.Gis.GeoUtilities.Shapes.ShapeType ShapeType 
        {
            get { return _shapeType; }
            protected set { _shapeType = value; }
        }

        #endregion


        #region ICloneable Members

        public abstract object Clone();

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type Shape.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public virtual void ItemCopy(object value)
        {
            try
            {
                if (value == null) throw new ArgumentNullException("value");
                Shape other = (Shape)value;
                _shapeType = other.ShapeType;
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


