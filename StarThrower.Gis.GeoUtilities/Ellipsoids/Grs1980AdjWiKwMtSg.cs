// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_KW_MT_SG
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378285.86, Flattening: 1 / 298.264183156421
    /// </summary>
    public class Grs1980AdjWiKwMtSg : Ellipsoid
    {
        internal Grs1980AdjWiKwMtSg()
        {
            this.EquatorialRadius = 6378285.86;
            this.Flattening = 1 / 298.264183156421;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


