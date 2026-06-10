// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_TR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378380.091, Flattening: 1 / 298.26858962751 
    /// </summary>
    public class Grs1980AdjWiTr : Ellipsoid
    {
        internal Grs1980AdjWiTr()
        {
            this.EquatorialRadius = 6378380.091;
            this.Flattening = 1 / 298.26858962751;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


