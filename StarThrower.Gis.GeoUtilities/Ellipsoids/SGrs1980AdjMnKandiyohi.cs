// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Kandiyohi
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378498.189, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnKandiyohi : Ellipsoid
    {
        internal SGrs1980AdjMnKandiyohi()
        {
            this.EquatorialRadius = 6378498.189;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


