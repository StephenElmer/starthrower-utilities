// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WK
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378376.871, Flattening: 1 / 298.268439052467
    /// </summary>
    public class Grs1980AdjWiWk : Ellipsoid
    {
        internal Grs1980AdjWiWk()
        {
            this.EquatorialRadius = 6378376.871;
            this.Flattening = 1 / 298.268439052467;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


