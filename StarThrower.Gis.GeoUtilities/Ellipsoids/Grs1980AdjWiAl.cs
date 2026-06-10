// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_AL
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378471.92, Flattening: 1 / 298.272883775229 
    /// </summary>
    public class Grs1980AdjWiAl : Ellipsoid
    {
        internal Grs1980AdjWiAl()
        {
            this.EquatorialRadius = 6378471.92;
            this.Flattening = 1 / 298.272883775229;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


