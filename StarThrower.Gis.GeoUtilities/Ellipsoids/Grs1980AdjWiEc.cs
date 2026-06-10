// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_EC
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378380.381, Flattening: 1 / 298.268603188617
    /// </summary>
    public class Grs1980AdjWiEc : Ellipsoid
    {
        internal Grs1980AdjWiEc()
        {
            this.EquatorialRadius = 6378380.381;
            this.Flattening = 1 / 298.268603188617;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


