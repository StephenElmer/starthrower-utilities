// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WS
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378405.971, Flattening: 1 / 298.269799839349
    /// </summary>
    public class Grs1980AdjWiWs : Ellipsoid
    {
        internal Grs1980AdjWiWs()
        {
            this.EquatorialRadius = 6378405.971;
            this.Flattening = 1 / 298.269799839349;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


