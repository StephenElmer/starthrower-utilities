// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_MA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378500.6, Flattening: 1 / 298.274224921888
    /// </summary>
    public class Grs1980AdjWiMa : Ellipsoid
    {
        internal Grs1980AdjWiMa()
        {
            this.EquatorialRadius = 6378500.6;
            this.Flattening = 1 / 298.274224921888;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


