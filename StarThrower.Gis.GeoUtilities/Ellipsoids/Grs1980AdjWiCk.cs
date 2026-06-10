// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_CK
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378470.401, Flattening: 1 / 298.272812743089
    /// </summary>
    public class Grs1980AdjWiCk : Ellipsoid
    {
        internal Grs1980AdjWiCk()
        {
            this.EquatorialRadius = 6378470.401;
            this.Flattening = 1 / 298.272812743089;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


