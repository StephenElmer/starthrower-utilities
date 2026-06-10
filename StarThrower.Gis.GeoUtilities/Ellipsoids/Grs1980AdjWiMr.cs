// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_MR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378438.991, Flattening: 1 / 298.27134393498
    /// </summary>
    public class Grs1980AdjWiMr : Ellipsoid
    {
        internal Grs1980AdjWiMr()
        {
            this.EquatorialRadius = 6378438.991;
            this.Flattening = 1 / 298.27134393498;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


