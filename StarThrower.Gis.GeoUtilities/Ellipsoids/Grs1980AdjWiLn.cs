// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_LN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378531.821, Flattening: 1 / 298.275684891897
    /// </summary>
    public class Grs1980AdjWiLn : Ellipsoid
    {
        internal Grs1980AdjWiLn()
        {
            this.EquatorialRadius = 6378531.821;
            this.Flattening = 1 / 298.275684891897;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


