// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WP
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378375.251, Flattening: 1 / 298.268363297321
    /// </summary>
    public class Grs1980AdjWiWp : Ellipsoid
    {
        internal Grs1980AdjWiWp()
        {
            this.EquatorialRadius = 6378375.251;
            this.Flattening = 1 / 298.268363297321;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


