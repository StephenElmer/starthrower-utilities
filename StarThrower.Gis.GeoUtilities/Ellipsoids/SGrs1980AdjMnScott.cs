// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Scott
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378421.989, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnScott : Ellipsoid
    {
        internal SGrs1980AdjMnScott()
        {
            this.EquatorialRadius = 6378421.989;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


