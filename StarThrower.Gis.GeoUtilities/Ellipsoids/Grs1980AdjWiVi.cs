// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_VI
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378624.171, Flattening: 1 / 298.280003402845
    /// </summary>
    public class Grs1980AdjWiVi : Ellipsoid
    {
        internal Grs1980AdjWiVi()
        {
            this.EquatorialRadius = 6378624.171;
            this.Flattening = 1 / 298.280003402845;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


