// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_CR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378379.031, Flattening: 1 / 298.268540059328
    /// </summary>
    public class Grs1980AdjWiCr : Ellipsoid
    {
        internal Grs1980AdjWiCr()
        {
            this.EquatorialRadius = 6378379.031;
            this.Flattening = 1 / 298.268540059328;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


