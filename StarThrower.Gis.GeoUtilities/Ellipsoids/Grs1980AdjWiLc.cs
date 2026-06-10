// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_LC
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378379.301, Flattening: 1 / 298.268552685186
    /// </summary>
    public class Grs1980AdjWiLc : Ellipsoid
    {
        internal Grs1980AdjWiLc()
        {
            this.EquatorialRadius = 6378379.301;
            this.Flattening = 1 / 298.268552685186;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


