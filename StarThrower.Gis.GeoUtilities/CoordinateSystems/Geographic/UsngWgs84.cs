// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// The United States National Grid (USNG), a WGS84-based alphanumeric grid reference system.
    /// </summary>
    /// <remarks>
    /// <see cref="ToGeodetic"/> and <see cref="FromGeodetic"/> do not currently perform any USNG
    /// grid-reference encoding or decoding; they accept and return plain decimal-degree coordinates unchanged.
    /// </remarks>
    public class UsngWgs84 : GeographicCoordinateSystem
    {
        #region Construction

        internal UsngWgs84() : base()
        {
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Returns the given coordinate unchanged. Does not decode a USNG grid reference;
        /// <paramref name="xLon"/>/<paramref name="yLat"/> are treated as plain decimal-degree
        /// longitude/latitude already.
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> containing the unchanged input coordinate.</returns>
        //TODO: #30 — does not perform USNG grid-reference encoding/decoding
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            return new Translations.GenericResult(xLon, yLat, zAlt);
        }

        /// <summary>
        /// Returns the given coordinate unchanged. Does not encode a USNG grid reference; the
        /// returned x/y values are plain decimal-degree longitude/latitude, not a USNG string.
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> containing the unchanged input coordinate.</returns>
        //TODO: #30 — does not perform USNG grid-reference encoding/decoding
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            return new Translations.GenericResult(xLon, yLat, zAlt);
        }

        #endregion
    }
}


