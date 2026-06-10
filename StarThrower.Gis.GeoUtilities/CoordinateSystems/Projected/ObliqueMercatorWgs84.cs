// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
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


