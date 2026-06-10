// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Chisago
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378411.321, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnChicago : Ellipsoid
    {
        internal SGrs1980AdjMnChicago()
        {
            this.EquatorialRadius = 6378411.321;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


