// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_ON
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378593.86, Flattening: 1 / 298.278585986653
    /// </summary>
    public class Grs1980AdjWiOn : Ellipsoid
    {
        internal Grs1980AdjWiOn()
        {
            this.EquatorialRadius = 6378593.86;
            this.Flattening = 1 / 298.278585986653;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


