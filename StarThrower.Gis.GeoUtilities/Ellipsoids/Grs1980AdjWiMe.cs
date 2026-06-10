// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_ME
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378406.601, Flattening: 1 / 298.269829299684
    /// </summary>
    public class Grs1980AdjWiMe : Ellipsoid
    {
        internal Grs1980AdjWiMe()
        {
            this.EquatorialRadius = 6378406.601;
            this.Flattening = 1 / 298.269829299684;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


