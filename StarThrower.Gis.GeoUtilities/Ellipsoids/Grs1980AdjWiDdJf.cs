// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_DD_JF
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378376.811, Flattening: 1 / 298.268436246721
    /// </summary>
    public class Grs1980AdjWiDdJf : Ellipsoid
    {
        internal Grs1980AdjWiDdJf()
        {
            this.EquatorialRadius = 6378376.811;
            this.Flattening = 1 / 298.268436246721;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


