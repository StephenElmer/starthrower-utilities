// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_CP
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378412.542, Flattening: 1 / 298.270107115315
    /// </summary>
    public class Grs1980AdjWiCp : Ellipsoid
    {
        internal Grs1980AdjWiCp()
        {
            this.EquatorialRadius = 6378412.542;
            this.Flattening = 1 / 298.270107115315;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


