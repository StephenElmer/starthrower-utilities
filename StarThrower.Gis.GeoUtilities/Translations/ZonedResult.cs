// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Translations
{
    /// <summary>
    /// A TranslationResult containing xLon, yLat, Altitude, and Zone values.
    /// The Zone value is an implementation of an IZone and is intended for use when
    /// translating INTO UTM, or similar, Projected Coordinate Systems.
    /// </summary>
    public class ZonedResult : TranslationResult
    {
        #region Private Instance Variables

        private IZone _zone;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the zone associated with the translated coordinate.
        /// </summary>
        public IZone Zone
        {
            get { return _zone; }
        }

        #endregion


        #region Construction

        internal ZonedResult(double xLon, double yLat, double zAlt, IZone zone) : this(xLon, yLat, zAlt, 0.0, 0.0, 0.0, zone) { }

        internal ZonedResult(double xLon, double yLat, double zAlt, double ce90, double le90, double se90, IZone zone)
        {
            this.xLon = xLon;
            this.yLat = yLat;
            this.zAlt = zAlt;
            this.ce90 = ce90;
            this.le90 = le90;
            this.se90 = se90;
            _zone = zone;
        }

        #endregion
    }
}


