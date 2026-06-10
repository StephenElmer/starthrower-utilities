// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_St_Louis_South
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378540.861, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnStLouisSouth : Ellipsoid
    {
        internal SGrs1980AdjMnStLouisSouth()
        {
            this.EquatorialRadius = 6378540.861;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
  }
}


