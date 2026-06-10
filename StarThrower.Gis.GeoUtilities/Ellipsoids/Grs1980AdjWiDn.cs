// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_DN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378407.621, Flattening: 1 / 298.269876997368
    /// </summary>
    public class Grs1980AdjWiDn : Ellipsoid
    {
        internal Grs1980AdjWiDn()
        {
            this.EquatorialRadius = 6378407.621;
            this.Flattening = 1 / 298.269876997368;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


