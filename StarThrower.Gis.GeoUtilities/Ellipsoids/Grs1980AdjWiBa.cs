// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_BA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378472.931, Flattening: 1 / 298.272931052052
    /// </summary>
    public class Grs1980AdjWiBa : Ellipsoid
    {
        internal Grs1980AdjWiBa()
        {
            this.EquatorialRadius = 6378472.931;
            this.Flattening = 1 / 298.272931052052;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


