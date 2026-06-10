// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WW
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378377.411, Flattening: 1 / 298.268464304182
    /// </summary>
    public class Grs1980AdjWiWw : Ellipsoid
    {
        internal Grs1980AdjWiWw()
        {
            this.EquatorialRadius = 6378377.411;
            this.Flattening = 1 / 298.268464304182;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


