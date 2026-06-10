// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// An implementation of the North American 1927 (NAD 27) Geographic Coordinate System
    /// </summary>
    public class GeodeticNad27 : GeographicCoordinateSystem
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

        internal GeodeticNad27() : this(HeightType.NoHeight) { }

        internal GeodeticNad27(HeightType heightType) : base()
        {
            _heightType = heightType;
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Nad1927Conus));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Translates the specified coordinates from GCS NAD 27 to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS NAD 27 coordinates.</param>
        /// <param name="yLat">yLat value in GCS NAD 27 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS NAD 27 coordinates</param>
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
        /// Translates the specified coordinates from GCS WGS84 to GCS NAD 27 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS NAD 27 coordinates.</returns>
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


