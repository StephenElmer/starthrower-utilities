// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_FN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378530.851, Flattening: 1 / 298.275639532334
    /// </summary>
    public class Grs1980AdjWiFn : Ellipsoid
    {
        internal Grs1980AdjWiFn()
        {
            this.EquatorialRadius = 6378530.851;
            this.Flattening = 1 / 298.275639532334;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


