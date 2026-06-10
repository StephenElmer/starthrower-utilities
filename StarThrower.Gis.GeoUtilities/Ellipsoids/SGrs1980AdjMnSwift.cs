// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Swift
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378470.757, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnSwift : Ellipsoid
    {
        internal SGrs1980AdjMnSwift()
        {
            this.EquatorialRadius = 6378470.757;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


