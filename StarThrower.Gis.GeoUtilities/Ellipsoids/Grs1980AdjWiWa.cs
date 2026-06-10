// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378407.141, Flattening: 1 / 298.269854551399
    /// </summary>
    public class Grs1980AdjWiWa : Ellipsoid
    {
        internal Grs1980AdjWiWa()
        {
            this.EquatorialRadius = 6378407.141;
            this.Flattening = 1 / 298.269854551399;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


