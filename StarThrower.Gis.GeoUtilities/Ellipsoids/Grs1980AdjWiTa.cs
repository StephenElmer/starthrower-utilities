// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_TA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378532.921, Flattening: 1 / 298.275736330576
    /// </summary>
    public class Grs1980AdjWiTa : Ellipsoid
    {
        internal Grs1980AdjWiTa()
        {
            this.EquatorialRadius = 6378532.921;
            this.Flattening = 1 / 298.275736330576;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


