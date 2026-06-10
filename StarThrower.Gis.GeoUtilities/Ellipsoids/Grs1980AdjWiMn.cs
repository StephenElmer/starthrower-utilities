// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_MN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378376.041, Flattening: 1 / 298.268400239645
    /// </summary>
    public class Grs1980AdjWiMn : Ellipsoid
    {
        internal Grs1980AdjWiMn()
        {
            this.EquatorialRadius = 6378376.041;
            this.Flattening = 1 / 298.268400239645;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


