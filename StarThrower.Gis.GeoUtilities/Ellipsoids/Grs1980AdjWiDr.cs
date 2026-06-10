// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_DR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378313.92, Flattening: 1 / 298.26549531037
    /// </summary>
    public class Grs1980AdjWiDr : Ellipsoid
    {
        internal Grs1980AdjWiDr()
        {
            this.EquatorialRadius = 6378313.92;
            this.Flattening = 1 / 298.26549531037;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


