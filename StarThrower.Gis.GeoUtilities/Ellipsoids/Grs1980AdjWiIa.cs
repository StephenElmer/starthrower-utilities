// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_IA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378408.041, Flattening: 1 / 298.269896637591
    /// </summary>
    public class Grs1980AdjWiIa : Ellipsoid
    {
        internal Grs1980AdjWiIa()
        {
            this.EquatorialRadius = 6378408.041;
            this.Flattening = 1 / 298.269896637591;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


