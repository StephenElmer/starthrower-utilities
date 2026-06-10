// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Kittson
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378449.421, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnKittson : Ellipsoid
    {
        internal SGrs1980AdjMnKittson()
        {
            this.EquatorialRadius = 6378449.421;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


