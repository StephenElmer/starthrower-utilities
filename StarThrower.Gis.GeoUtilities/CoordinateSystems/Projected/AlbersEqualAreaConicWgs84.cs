// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// This class provides conversions between Geodetic coordinates
    /// (latitude and longitude in radians) and Albers Equal Area Conic
    /// projection coordinates (easting and northing in meters) defined
    /// by two standard parallels.
    /// </summary>
    /// <remarks>
    /// REFERENCES:
    /// 
    ///    Further information on ALBERS can be found in the Reuse Manual.
    ///
    ///    ALBERS originated from:     U.S. Army Topographic Engineering Center
    ///                                Geospatial Information Division
    ///                                7701 Telegraph Road
    ///                                Alexandria, VA  22310-3864
    /// </remarks>
    public class AlbersEqualAreaConicWgs84 : ProjectedCoordinateSystem
    {

        #region Construction

        internal AlbersEqualAreaConicWgs84() : this(0.0, 0.0, 0.0, 0.0, 0.0, 0.0) { }

        internal AlbersEqualAreaConicWgs84(double falseEasting, double falseNorthing, double centralMeridian, double latitudeOfOrigin, double standardParallel1, double standardParallel2)
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs84));
            this.Projection = new Projections.AlbersEqualAreaConic(falseEasting, falseNorthing, centralMeridian, latitudeOfOrigin, standardParallel1, standardParallel2);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Not yet implemented: this override does not convert AlbersEqualAreaConicWgs84
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
        /// to AlbersEqualAreaConicWgs84 projected (easting/northing) coordinates. It returns the
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


