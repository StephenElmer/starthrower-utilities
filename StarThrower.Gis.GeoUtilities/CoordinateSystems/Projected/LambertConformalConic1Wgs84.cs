// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    public class LambertConformalConic1Wgs84 : ProjectedCoordinateSystem
    {
        #region Construction

        internal LambertConformalConic1Wgs84() : this(0.0, 0.0, 0.0, 1.0, 0.0) { }

        internal LambertConformalConic1Wgs84(double falseEasting, double falseNorthing, double centralMeridian, double latitudeOfOrigin, double scaleFactor)
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs84));
            this.Projection = new Projections.LambertConformalConic1(falseEasting, falseNorthing, centralMeridian, latitudeOfOrigin, scaleFactor);
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


