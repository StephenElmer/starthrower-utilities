// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_BN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378414.96, Flattening: 1 / 298.270220186885
    /// </summary>
    public class Grs1980AdjWiBn : Ellipsoid
    {
        internal Grs1980AdjWiBn()
        {
            this.EquatorialRadius = 6378414.96;
            this.Flattening = 1 / 298.270220186885;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


