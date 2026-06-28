// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Translations
{

    /// <summary>
    /// A <see cref="TranslationResult"/> that also carries the translated coordinate's
    /// formatted string representation.
    /// </summary>
    public class StringResult : TranslationResult
    {
        #region Private Instance Variables

        private string _coordString = String.Empty;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the formatted string representation of the translated coordinate.
        /// </summary>
        public string CoordString
        {
            get { return _coordString; }
        }

        #endregion


        #region Construction

        internal StringResult(double xLon, double yLat, double zAlt, string coordString) : this(xLon, yLat, zAlt, 0.0, 0.0, 0.0, coordString) { }

        internal StringResult(double xLon, double yLat, double zAlt, double ce90, double le90, double se90, string coordString)
        {
            this.xLon = xLon;
            this.yLat = yLat;
            this.zAlt = zAlt;
            this.ce90 = ce90;
            this.le90 = le90;
            this.se90 = se90;
            _coordString = coordString;
        }

        #endregion
    }
}


