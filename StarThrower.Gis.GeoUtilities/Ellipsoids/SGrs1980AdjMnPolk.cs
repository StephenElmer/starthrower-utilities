// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Polk
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378445.763, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnPolk : Ellipsoid
    {
        internal SGrs1980AdjMnPolk()
        {
            this.EquatorialRadius = 6378445.763;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


