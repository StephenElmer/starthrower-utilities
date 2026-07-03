// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// A <see cref="Projections.LocalCartesian"/>-projected coordinate system based on the WGS84
    /// geodetic datum.
    /// </summary>
    public class LocalCartesianWgs84 : ProjectedCoordinateSystem
    {
        #region Public Methods

        /// <summary>
        /// Gets how this coordinate system's vertical (height) component should be interpreted.
        /// Overridden to return <see cref="HeightType.EllipsoidHeight"/> rather than the base
        /// class's <see cref="HeightType.NoHeight"/>, since Local Cartesian coordinates are
        /// defined relative to an origin height above the ellipsoid.
        /// </summary>
        public override HeightType HeightType
        {
            get { return HeightType.EllipsoidHeight; }
        }

        #endregion


        #region Construction

        internal LocalCartesianWgs84() : this(0.0, 0.0, 0.0, 0.0) { }

        internal LocalCartesianWgs84(double latitudeOfOrigin, double longitudeOfOrigin, double originHeight, double orientation)
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs84));
            this.Projection = new Projections.LocalCartesian(latitudeOfOrigin, longitudeOfOrigin, originHeight, orientation);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Not yet implemented: this override does not convert LocalCartesianWgs84
        /// projected (easting/northing) coordinates to geodetic coordinates. It
        /// returns the input values unchanged.
        /// </summary>
        /// <param name="xLon">The x (easting) coordinate.</param>
        /// <param name="yLat">The y (northing) coordinate.</param>
        /// <param name="zAlt">The vertical (height/altitude) coordinate.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> wrapping the unconverted input coordinate.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: #11 — implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Not yet implemented: this override does not convert geodetic coordinates
        /// to LocalCartesianWgs84 projected (easting/northing) coordinates. It returns the
        /// input values unchanged.
        /// </summary>
        /// <param name="xLon">The longitude.</param>
        /// <param name="yLat">The latitude.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> wrapping the unconverted input coordinate.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: #11 — implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        #endregion
    }
}


