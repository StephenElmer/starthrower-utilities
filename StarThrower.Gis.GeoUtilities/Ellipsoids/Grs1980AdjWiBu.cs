// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_BU
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378380.991, Flattening: 1 / 298.268631713702
    /// </summary>
    public class Grs1980AdjWiBu : Ellipsoid
    {
        internal Grs1980AdjWiBu()
        {
            this.EquatorialRadius = 6378380.991;
            this.Flattening = 1 / 298.268631713702;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


