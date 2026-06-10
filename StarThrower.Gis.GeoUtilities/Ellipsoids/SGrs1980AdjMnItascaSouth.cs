// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Itasca_South
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378574.389, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnItascaSouth : Ellipsoid
    {
        internal SGrs1980AdjMnItascaSouth()
        {
            this.EquatorialRadius = 6378574.389;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


