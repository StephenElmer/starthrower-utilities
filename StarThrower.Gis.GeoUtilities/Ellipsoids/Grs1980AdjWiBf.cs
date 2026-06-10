// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_BF
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378411.351, Flattening: 1 / 298.270051421254
    /// </summary>
    public class Grs1980AdjWiBf : Ellipsoid
    {
        internal Grs1980AdjWiBf()
        {
            this.EquatorialRadius = 6378411.351;
            this.Flattening = 1 / 298.270051421254;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


