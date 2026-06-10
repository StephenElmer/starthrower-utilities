// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_CL_FL_OG_WN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378345.09, Flattening: 1 / 298.266952895494
    /// </summary>
    public class Grs1980AdjWiClFlOgWn : Ellipsoid
    {
        internal Grs1980AdjWiClFlOgWn()
        {
            this.EquatorialRadius = 6378345.09;
            this.Flattening = 1 / 298.266952895494;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


