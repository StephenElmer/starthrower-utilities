// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Translations
{
    /// <summary>
    /// A TranslationResult containing xLon, yLat, and Altitude values.
    /// </summary>
    public class GenericResult : TranslationResult
    {
        #region Construction

        internal GenericResult(double xLon, double yLat, double zAlt) : this(xLon, yLat, zAlt, 0.0, 0.0, 0.0) { }

        internal GenericResult(double xLon, double yLat, double zAlt, double ce90, double le90, double se90)
        {
            this.xLon = xLon;
            this.yLat = yLat;
            this.zAlt = zAlt;
            this.ce90 = ce90;
            this.le90 = le90;
            this.se90 = se90;
        }

        #endregion
    }
}


