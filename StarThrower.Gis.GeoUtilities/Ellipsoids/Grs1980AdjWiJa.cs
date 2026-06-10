// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_JA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378409.151, Flattening: 1 / 298.269948543895
    /// </summary>
    public class Grs1980AdjWiJa : Ellipsoid
    {
        internal Grs1980AdjWiJa()
        {
            this.EquatorialRadius = 6378409.151;
            this.Flattening = 1 / 298.269948543895;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


