// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_SK
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378407.281, Flattening: 1 / 298.26986109814
    /// </summary>
    public class Grs1980AdjWiSk : Ellipsoid
    {
        internal Grs1980AdjWiSk()
        {
            this.EquatorialRadius = 6378407.281;
            this.Flattening = 1 / 298.26986109814;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


