// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_RK
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378377.671, Flattening: 1 / 298.268476462415
    /// </summary>
    public class Grs1980AdjWiRk : Ellipsoid
    {
        internal Grs1980AdjWiRk()
        {
            this.EquatorialRadius = 6378377.671;
            this.Flattening = 1 / 298.268476462415;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


