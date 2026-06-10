// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_LG
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378560.121, Flattening: 1 / 298.277008268831
    /// </summary>
    public class Grs1980AdjWiLg : Ellipsoid
    {
        internal Grs1980AdjWiLg()
        {
            this.EquatorialRadius = 6378560.121;
            this.Flattening = 1 / 298.277008268831;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


