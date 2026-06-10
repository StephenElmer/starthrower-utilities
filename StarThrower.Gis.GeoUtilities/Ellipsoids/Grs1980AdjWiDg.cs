// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_DG
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378414.93, Flattening: 1 / 298.270218784012
    /// </summary>
    public class Grs1980AdjWiDg : Ellipsoid
    {
        internal Grs1980AdjWiDg()
        {
            this.EquatorialRadius = 6378414.93;
            this.Flattening = 1 / 298.270218784012;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


