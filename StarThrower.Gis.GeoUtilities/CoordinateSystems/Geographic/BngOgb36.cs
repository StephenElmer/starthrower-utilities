// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    public class BngOgb36 : GeographicCoordinateSystem
    {
        #region Construction

        internal BngOgb36() : base()
        {
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Ogb1936Mean));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Translates the specified coordinates from GCS WGS84 to GCS WGS84 coordinates
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            return new Translations.GenericResult(xLon, yLat, zAlt);
        }

        /// <summary>
        /// Translates the specified coordinates from GCS WGS84 to GCS WGS84 coordinates.
        /// </summary>
        /// <param name="xLon">xLon value in GCS WGS84 coordinates.</param>
        /// <param name="yLat">yLat value in GCS WGS84 coordinates</param>
        /// <param name="zAlt">Altitude value in GCS WGS84 coordinates</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing GCS WGS84 coordinates.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            return new Translations.GenericResult(xLon, yLat, zAlt);
        }

        #endregion
    }
}


