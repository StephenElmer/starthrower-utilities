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

namespace StarThrower.Gis.GeoUtilities
{
    public class GeoRectangle
    {
        #region Private Member Variables

        private GeoPoint _upperLeft = new GeoPoint();
        private GeoPoint _lowerRight = new GeoPoint();

        #endregion


        #region Public Properties

        public double Bottom
        {
            get { return _lowerRight.yLat; }
            set { _lowerRight.yLat = value; }
        }

        public double Height
        {
            get { return _lowerRight.yLat - _upperLeft.yLat; }
            set { _lowerRight.yLat = _upperLeft.yLat + value;  }
        }

        public bool IsEmpty
        {
            get { return _upperLeft.xLon == 0.0 && _upperLeft.yLat == 0.0 && _lowerRight.xLon == 0.0 && _lowerRight.yLat == 0.0; }
        }

        public double Left
        {
            get { return _upperLeft.xLon; }
            set { _upperLeft.xLon = value; }
        }

        public GeoPoint Location
        {
            get { return _upperLeft; }
            set { _upperLeft = value; }
        }

        public double Right
        {
            get { return _lowerRight.xLon; }
            set { _lowerRight.xLon = value; }
        }

        public double Top
        {
            get { return _upperLeft.yLat; }
            set { _upperLeft.yLat = value; }
        }

        public double Width
        {
            get { return _lowerRight.xLon - _upperLeft.xLon; }
            set { _lowerRight.xLon = _upperLeft.xLon + value; }
        }

        public double X
        {
            get { return _upperLeft.xLon; }
            set { _upperLeft.xLon = value; }
        }

        public double Y
        {
            get { return _upperLeft.yLat; }
            set { _upperLeft.yLat = value; }
        }

        #endregion


        #region Construction

        public GeoRectangle() { }

        public GeoRectangle(double x1, double y1, double x2, double y2) : this()
        {
            _upperLeft.xLon = x1;
            _upperLeft.yLat = y1;
            _lowerRight.xLon = x2;
            _lowerRight.yLat = y2;
        }

        public GeoRectangle(GeoPoint upperLeft, GeoPoint lowerRight) : this()
        {
            ArgumentNullException.ThrowIfNull(upperLeft);
            ArgumentNullException.ThrowIfNull(lowerRight);

            _upperLeft = (GeoPoint)(upperLeft.Clone());
            _lowerRight = (GeoPoint)(lowerRight.Clone());
        }

        #endregion
    }
}


