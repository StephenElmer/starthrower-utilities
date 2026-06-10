// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_SW
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378534.451, Flattening: 1 / 298.275807877103
    /// </summary>
    public class Grs1980AdjWiSw : Ellipsoid
    {
        internal Grs1980AdjWiSw()
        {
            this.EquatorialRadius = 6378534.451;
            this.Flattening = 1 / 298.275807877103;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


