// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_DU
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378413.021, Flattening: 1 / 298.270129514522
    /// </summary>
    public class Grs1980AdjWiDu : Ellipsoid
    {
        internal Grs1980AdjWiDu()
        {
            this.EquatorialRadius = 6378413.021;
            this.Flattening = 1 / 298.270129514522;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


