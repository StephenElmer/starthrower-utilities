// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_RC
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378408.091, Flattening: 1 / 298.269898975713
    /// </summary>
    public class Grs1980AdjWiRc : Ellipsoid
    {
        internal Grs1980AdjWiRc()
        {
            this.EquatorialRadius = 6378408.091;
            this.Flattening = 1 / 298.269898975713;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


