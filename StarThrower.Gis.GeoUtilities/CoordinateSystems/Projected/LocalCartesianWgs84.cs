// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    public class LocalCartesianWgs84 : ProjectedCoordinateSystem
    {
        #region Public Methods

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

        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            //TODO: implement this translation
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

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


