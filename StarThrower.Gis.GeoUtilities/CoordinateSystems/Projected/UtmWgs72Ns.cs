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

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// An implementation of the Universal Transverse Mercator (UTM) Projected Coordinate System based upon the WGS72 Datum.
    /// This variation provides only the North / South variation ranging from 1 thru 60 longitudinal zones with 
    /// just North and South latitudinal zones.
    /// </summary>
    public class UtmWgs72Ns : ProjectedCoordinateSystem
    {
        #region Private Instance Variables

        private IZone _zone;

        #endregion


        #region Public Properties

        public override string Name
        {
            get { return this.GetType().Name + "_" + _zone.Name; }
        }

        public override string Key
        {
            get
            {
                if (_zone is Zones.UndefinedZone)
                {
                    return base.Key;
                }
                else
                {
                    return this.GetType().Name + "_" + _zone.Name;
                }
            }
        }

        public IZone Zone
        {
            get { return _zone; }
        }

        #endregion


        #region Construction

        internal UtmWgs72Ns() : this(new Zones.UndefinedZone()) { }

        internal UtmWgs72Ns(IZone zone)
        {
            if (!(zone is Zones.UtmNs.UtmNsZone) && !(zone is Zones.UndefinedZone)) throw new ArgumentException("invalid zone", "zone");

            _zone = zone;
            double centralMeridianValue = _zone.CentralMeridian;
            double latitudeOfOriginValue = _zone.ReferenceLatitude;
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs72));
            this.Projection = new Projections.TransverseMercator(500000.0, 0.0, centralMeridianValue, 0.9996, latitudeOfOriginValue);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Translates the specified coordinates from UTM (WGS72) to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in UTM (WGS72) coordinates.</param>
        /// <param name="yLat">yLat value in UTM (WGS72) coordinates</param>
        /// <param name="zAlt">Altitude value in UTM (WGS72) coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //IZone zone = new Zones.UtmNs.UtmNsZone(xLon, yLat);
            //IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(this.GetType(), zone);
            //if (cs == this)
            //{
                double resultLon = 0.0;
                double resultLat = 0.0;
                double resultAlt = zAlt;
                GeoUtil.UtmToLatLonDetail(xLon, yLat, this, ref resultLon, ref resultLat);
                return new Translations.ZonedResult(resultLon, resultLat, resultAlt, _zone);
            //}
            //else
            //{
            //    return cs.ToGeodetic(xLon, yLat, zAlt);
            //}
        }

        /// <summary>
        /// Translates the specified coordinates from GCS WGS84 to UTM WGS72 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A ZonedResult implementation of the ITranslationResult, containing UTM WGS72 coordinates.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            IZone zone = new Zones.UtmNs.UtmNsZone(xLon, yLat);

            IProjectedCoordinateSystem cs = ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(this.GetType(), zone);
            if (cs == this)
            {
                double resultLon = 0.0;
                double resultLat = 0.0;
                double resultAlt = zAlt;

                GeoUtil.LatLonToUtmDetail(xLon, yLat, this, ref resultLon, ref resultLat);

                return new Translations.ZonedResult(resultLon, resultLat, resultAlt, zone);
            }
            else
            {
                return cs.FromGeodetic(xLon, yLat, zAlt);
            }
        }

        #endregion
    }
}
