// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_SC
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378412.511, Flattening: 1 / 298.270105665679
    /// </summary>
    public class Grs1980AdjWiSc : Ellipsoid
    {
        internal Grs1980AdjWiSc()
        {
            this.EquatorialRadius = 6378412.511;
            this.Flattening = 1 / 298.270105665679;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


