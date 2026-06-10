// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: S_GRS_1980_Adj_MN_Itasca_North
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378574.389, Flattening: 1 / 298.2572221008827
    /// </summary>
    public class SGrs1980AdjMnItascaNorth : Ellipsoid
    {
        internal SGrs1980AdjMnItascaNorth()
        {
            this.EquatorialRadius = 6378574.389;
            this.Flattening = 1 / 298.2572221008827;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


