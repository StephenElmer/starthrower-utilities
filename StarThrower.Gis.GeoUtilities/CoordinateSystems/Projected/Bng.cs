// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// This component provides conversions between Geodetic coordinates 
    /// (latitude and longitude) and British National Grid coordinates.
    /// </summary>
    public class Bng : ProjectedCoordinateSystem
    {
        #region Construction

        internal Bng()
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticOgb36));
            this.Projection = new Projections.TransverseMercator(400000.0, -100000.0, -2.0, 0.999601272, 49.0);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Translates the specified coordinates from BNG to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in BNG coordinates.</param>
        /// <param name="yLat">yLat value in BNG coordinates</param>
        /// <param name="zAlt">Altitude value in BNG coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Translates the specified coordinates from GCS WGS84 to BNG coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing BNG coordinates.</returns>
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


