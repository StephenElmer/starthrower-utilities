// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// A <see cref="Projections.EquidistantCylindrical"/>-projected coordinate system based on the WGS84
    /// geodetic datum.
    /// </summary>
    public class EquidistantCylindricalWgs84 : ProjectedCoordinateSystem
    {
        #region Construction

        internal EquidistantCylindricalWgs84() : this(0.0, 0.0, 0.0, 0.0) { }

        internal EquidistantCylindricalWgs84(double falseEasting, double falseNorthing, double centralMeridian, double standardParallel)
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs84));
            this.Projection = new Projections.EquidistantCylindrical(falseEasting, falseNorthing, centralMeridian, standardParallel);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Not yet implemented: this override does not convert EquidistantCylindricalWgs84
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
        /// to EquidistantCylindricalWgs84 projected (easting/northing) coordinates. It returns the
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


