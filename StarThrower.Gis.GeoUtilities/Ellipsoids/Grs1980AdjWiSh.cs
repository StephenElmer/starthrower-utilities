// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_SH
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378406.051, Flattening: 1 / 298.269803580344
    /// </summary>
    public class Grs1980AdjWiSh : Ellipsoid
    {
        internal Grs1980AdjWiSh()
        {
            this.EquatorialRadius = 6378406.051;
            this.Flattening = 1 / 298.269803580344;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


