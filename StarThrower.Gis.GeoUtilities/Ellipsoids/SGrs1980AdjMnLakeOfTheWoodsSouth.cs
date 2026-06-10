// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Lake_of_the_Woods_South
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378496.665, Flattening: 1 / 298.2572221008827 
    /// </summary>
    public class SGrs1980AdjMnLakeOfTheWoodsSouth : Ellipsoid
    {
        internal SGrs1980AdjMnLakeOfTheWoodsSouth()
        {
            this.EquatorialRadius = 6378496.665;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


