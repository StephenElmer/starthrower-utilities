// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// A <see cref="Projections.ObliqueMercator"/>-projected coordinate system based on the WGS84
    /// geodetic datum.
    /// </summary>
    public class ObliqueMercatorWgs84 : ProjectedCoordinateSystem
    {
        #region Construction

        internal ObliqueMercatorWgs84() : this(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0) { }

        internal ObliqueMercatorWgs84(double falseEasting, double falseNorthing, double latitudeOfOrigin, double latitude1, double longitude1, double latitude2, double longitude2, double scaleFactor)
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs84));
            this.Projection = new Projections.ObliqueMercator(falseEasting, falseNorthing, latitudeOfOrigin, latitude1, longitude1, latitude2, longitude2, scaleFactor);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Not yet implemented: this override does not convert ObliqueMercatorWgs84
        /// projected (easting/northing) coordinates to geodetic coordinates. It
        /// returns the input values unchanged.
        /// </summary>
        /// <param name="xLon">The x (easting) coordinate.</param>
        /// <param name="yLat">The y (northing) coordinate.</param>
        /// <param name="zAlt">The vertical (height/altitude) coordinate.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> wrapping the unconverted input coordinate.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Not yet implemented: this override does not convert geodetic coordinates
        /// to ObliqueMercatorWgs84 projected (easting/northing) coordinates. It returns the
        /// input values unchanged.
        /// </summary>
        /// <param name="xLon">The longitude.</param>
        /// <param name="yLat">The latitude.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> wrapping the unconverted input coordinate.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        #endregion
    }
}


