// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Wabasha
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378426.561, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnWabasha : Ellipsoid
    {
        internal SGrs1980AdjMnWabasha()
        {
            this.EquatorialRadius = 6378426.561;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


