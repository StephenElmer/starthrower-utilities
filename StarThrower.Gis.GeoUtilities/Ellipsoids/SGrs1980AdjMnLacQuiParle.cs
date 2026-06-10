// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Lac_Qui_Parle
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378476.853, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnLacQuiParle : Ellipsoid
    {
        internal SGrs1980AdjMnLacQuiParle()
        {
            this.EquatorialRadius = 6378476.853;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


