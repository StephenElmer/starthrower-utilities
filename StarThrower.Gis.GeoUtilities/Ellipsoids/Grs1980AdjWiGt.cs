// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_GT
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378378.881, Flattening: 1 / 298.268533044963
    /// </summary>
    public class Grs1980AdjWiGt : Ellipsoid
    {
        internal Grs1980AdjWiGt()
        {
            this.EquatorialRadius = 6378378.881;
            this.Flattening = 1 / 298.268533044963;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


