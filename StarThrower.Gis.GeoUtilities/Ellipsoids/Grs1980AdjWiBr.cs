// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_BR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378137.0, Flattening: 1 / 298.257222100225
    /// </summary>
    public class Grs1980AdjWiBr : Ellipsoid
    {
        internal Grs1980AdjWiBr()
        {
            this.EquatorialRadius = 6378137.0;
            this.Flattening = 1 / 298.257222100225;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


