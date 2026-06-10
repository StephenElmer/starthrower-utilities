// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_GR_LF
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378408.481, Flattening: 1 / 298.269917213063
    /// </summary>
    public class Grs1980AdjWiGrLf : Ellipsoid
    {
        internal Grs1980AdjWiGrLf()
        {
            this.EquatorialRadius = 6378408.481;
            this.Flattening = 1 / 298.269917213063;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


