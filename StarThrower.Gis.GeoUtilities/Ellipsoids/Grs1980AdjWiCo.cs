// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_CO
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378376.331, Flattening: 1 / 298.268413800752
    /// </summary>
    public class Grs1980AdjWiCo : Ellipsoid
    {
        internal Grs1980AdjWiCo()
        {
            this.EquatorialRadius = 6378376.331;
            this.Flattening = 1 / 298.268413800752;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


