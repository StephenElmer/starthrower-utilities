// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_OC
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378345.42, Flattening: 1 / 298.266968327098
    /// </summary>
    public class Grs1980AdjWiOc : Ellipsoid
    {
        internal Grs1980AdjWiOc()
        {
            this.EquatorialRadius = 6378345.42;
            this.Flattening = 1 / 298.266968327098;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


