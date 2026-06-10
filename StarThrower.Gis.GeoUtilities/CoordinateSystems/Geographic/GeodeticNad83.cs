// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// An implementation of the North American 1983 (NAD 83) Geographic Coordinate System
    /// </summary>
    public class GeodeticNad83 : GeographicCoordinateSystem
    {
        #region Private Instance Variables

        private HeightType _heightType = HeightType.NoHeight;

        #endregion


        #region Public Properties

        public override HeightType HeightType
        {
            get { return _heightType; }
        }

        #endregion


        #region Construction

        internal GeodeticNad83() : this(HeightType.NoHeight) { }

        internal GeodeticNad83(HeightType heightType) : base()
        {
            _heightType = heightType;
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1983Conus));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Translates the specified coordinates from GCS OSGB 1936 to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS NAD 83 coordinates.</param>
        /// <param name="yLat">yLat value in GCS NAD 83 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS NAD 83 coordinates</param>
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
        /// Translates the specified coordinates from GCS WGS84 to GCS NAD83 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS NAD 83 coordinates.</returns>
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


