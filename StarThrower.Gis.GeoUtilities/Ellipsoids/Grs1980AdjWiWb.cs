// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WB
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378474.591, Flattening: 1 / 298.273008677695
    /// </summary>
    public class Grs1980AdjWiWb : Ellipsoid
    {
        internal Grs1980AdjWiWb()
        {
            this.EquatorialRadius = 6378474.591;
            this.Flattening = 1 / 298.273008677695;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


