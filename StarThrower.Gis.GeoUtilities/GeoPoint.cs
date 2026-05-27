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
using StarThrower.Logging;
using StarThrower.Gis.GeoUtilities.Formatting;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities
{
    public class GeoPoint : IGeoPoint, ICloneable
    {
        #region Private Member Variables

        private double _yLat = 0;
        private double _xLon = 0;
        private IDmsFormatter _dmsFormatter = DmsFormatterFactory.Create(DmsFormat.Default);

        #endregion


        #region Public Properties

        /// <summary>
        /// Sets/Gets yLat in decimal degrees (DD format)
        /// </summary>
        public double yLat
        {
            get { return _yLat; }
            set { _yLat = value; }
        }

        /// <summary>
        /// Sets/Gets xLon in decimal degrees (DD format)
        /// </summary>
        public double xLon
        {
            get { return _xLon; }
            set { _xLon = value; }
        }

        /// <summary>
        /// Sets/Gets yLat in a DMS format
        /// </summary>
        public string yLatDms
        {
            get { return _dmsFormatter.DdToDmsNs(_yLat); }
            set { _yLat = _dmsFormatter.DmsToDdNs(value); }
        }

        /// <summary>
        /// Sets/Gets xLon in a DMS format
        /// </summary>
        public string xLonDms
        {
            get { return _dmsFormatter.DdToDmsEw(_xLon); }
            set { _xLon = _dmsFormatter.DmsToDdEw(value); }
        }

        #endregion


        #region Construction

        public GeoPoint() : this(0, 0) { }
        
        public GeoPoint(double xLon, double yLat)
        {
            _yLat = yLat;
            _xLon = xLon;
        }
        
        public GeoPoint(GeoPoint other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public virtual object Clone()
        {
            return new GeoPoint(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type GeoPoint.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public void ItemCopy(object value)
        {
            try
            {
                if (value == null) throw new ArgumentNullException("value");
                GeoPoint other = value as GeoPoint;
                this.yLat = other.yLat;
                this.xLon = other.xLon;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".ItemCopy(object)", ex);
                throw new FailedItemCopyException("Failed to copy item.", ex);
            }
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is GeoPoint)) return false;
            GeoPoint other = (GeoPoint)obj;
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
            return "[GeoPoint:  x=" + this.xLon + ", y=" + this.yLat + "]";
        }

        #endregion
    }
}
