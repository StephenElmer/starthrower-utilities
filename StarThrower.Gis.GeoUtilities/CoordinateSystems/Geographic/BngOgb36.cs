// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// The geographic coordinate system underlying the British National Grid, based on the mean
    /// Ordnance Survey of Great Britain 1936 (OSGB36) datum.
    /// </summary>
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
        /// Returns the given coordinate unchanged, since this coordinate system's native
        /// representation is already geodetic (latitude/longitude) in the OSGB36 (mean) datum.
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> containing the unchanged input coordinate.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            return new Translations.GenericResult(xLon, yLat, zAlt);
        }

        /// <summary>
        /// Returns the given coordinate unchanged, since this coordinate system's native
        /// representation is already geodetic (latitude/longitude) in the OSGB36 (mean) datum.
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> containing the unchanged input coordinate.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            return new Translations.GenericResult(xLon, yLat, zAlt);
        }

        #endregion
    }
}


