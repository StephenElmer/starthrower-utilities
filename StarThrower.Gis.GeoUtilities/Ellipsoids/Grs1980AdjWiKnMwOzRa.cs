// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_KN_MW_OZ_RA
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378315.7, Flattening: 1 / 298.265578547505
    /// </summary>
    public class Grs1980AdjWiKnMwOzRa : Ellipsoid
    {
        internal Grs1980AdjWiKnMwOzRa()
        {
            this.EquatorialRadius = 6378315.7;
            this.Flattening = 1 / 298.265578547505;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


