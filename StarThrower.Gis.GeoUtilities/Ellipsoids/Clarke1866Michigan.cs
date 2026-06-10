// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1866_Michigan
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378450.047, Flattening: 1 / 294.978684677
    /// </summary>
    public class Clarke1866Michigan : Ellipsoid
    {
        internal Clarke1866Michigan()
        {
            this.EquatorialRadius = 6378450.047;
            this.Flattening = 1 / 294.978684677;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


