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

namespace StarThrower.Gis.GeoUtilities.Translations
{
    /// <summary>
    /// A TranslationResult containing xLon, yLat, Altitude, and Zone values.
    /// The Zone value is an implementation of an IZone and is intended for use when
    /// translating INTO UTM, or similar, Projected Coordinate Systems.
    /// </summary>
    public class ZonedResult : TranslationResult
    {
        #region Private Instance Variables

        private IZone _zone;

        #endregion


        #region Public Properties

        public IZone Zone
        {
            get { return _zone; }
        }

        #endregion


        #region Construction

        internal ZonedResult(double xLon, double yLat, double zAlt, IZone zone) : this(xLon, yLat, zAlt, 0.0, 0.0, 0.0, zone) { }

        internal ZonedResult(double xLon, double yLat, double zAlt, double ce90, double le90, double se90, IZone zone)
        {
            this.xLon = xLon;
            this.yLat = yLat;
            this.zAlt = zAlt;
            this.ce90 = ce90;
            this.le90 = le90;
            this.se90 = se90;
            _zone = zone;
        }

        #endregion
    }
}


