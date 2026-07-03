// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// An implementation of the World Geodetic System 1972 (WGS 72) Geographic Coordinate System
    /// </summary>
    public class GeodeticWgs72 : GeographicCoordinateSystem
    {
        #region Private Instance Variables

        private HeightType _heightType = HeightType.NoHeight;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets how this coordinate system's vertical (height) component should be interpreted.
        /// Defaults to <see cref="HeightType.NoHeight"/>, but can be set to a different value via
        /// the <see cref="HeightType"/>-accepting constructor.
        /// </summary>
        public override HeightType HeightType
        {
            get { return _heightType; }
        }

        #endregion


        #region Construction

        internal GeodeticWgs72() : this(HeightType.NoHeight) { }

        internal GeodeticWgs72(HeightType heightType) : base()
        {
            _heightType = heightType;
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1972));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Returns the given coordinate unchanged, since this coordinate system's native
        /// representation is already geodetic (latitude/longitude) in the WGS 72 datum. Any
        /// shift to/from WGS84 is applied separately via <see cref="IDatum.ToWgs84"/>/
        /// <see cref="IDatum.FromWgs84"/> (see <see cref="GeoUtil.Translate"/>).
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> containing the unchanged input coordinate.</returns>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Returns the given coordinate unchanged, since this coordinate system's native
        /// representation is already geodetic (latitude/longitude) in the WGS 72 datum. Any
        /// shift to/from WGS84 is applied separately via <see cref="IDatum.ToWgs84"/>/
        /// <see cref="IDatum.FromWgs84"/> (see <see cref="GeoUtil.Translate"/>).
        /// </summary>
        /// <param name="xLon">The longitude, in decimal degrees.</param>
        /// <param name="yLat">The latitude, in decimal degrees.</param>
        /// <param name="zAlt">The height/altitude.</param>
        /// <returns>A <see cref="Translations.GenericResult"/> containing the unchanged input coordinate.</returns>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            double resultLon = xLon;
            double resultLat = yLat;
            double resultAlt = zAlt;
            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        #endregion
    }
}


