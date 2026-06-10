// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_PT
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378344.377, Flattening: 1 / 298.266919538913
    /// </summary>
    public class Grs1980AdjWiPt : Ellipsoid
    {
        internal Grs1980AdjWiPt()
        {
            this.EquatorialRadius = 6378344.377;
            this.Flattening = 1 / 298.266919538913;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


