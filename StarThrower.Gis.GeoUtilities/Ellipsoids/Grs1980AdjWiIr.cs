// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_IR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378655.071, Flattening: 1 / 298.281448362111
    /// </summary>
    public class Grs1980AdjWiIr : Ellipsoid
    {
        internal Grs1980AdjWiIr()
        {
            this.EquatorialRadius = 6378655.071;
            this.Flattening = 1 / 298.281448362111;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


