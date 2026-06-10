// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_RS
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378472.751, Flattening: 1 / 298.272922634813
    /// </summary>
    public class Grs1980AdjWiRs : Ellipsoid
    {
        internal Grs1980AdjWiRs()
        {
            this.EquatorialRadius = 6378472.751;
            this.Flattening = 1 / 298.272922634813;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


