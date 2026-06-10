// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_PR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378563.891, Flattening: 1 / 298.277184563214
    /// </summary>
    public class Grs1980AdjWiPr : Ellipsoid
    {
        internal Grs1980AdjWiPr()
        {
            this.EquatorialRadius = 6378563.891;
            this.Flattening = 1 / 298.277184563214;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


