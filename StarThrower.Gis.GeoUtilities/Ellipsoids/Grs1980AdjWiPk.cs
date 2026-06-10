// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_PK
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378413.671, Flattening: 1 / 298.270159910105
    /// </summary>
    public class Grs1980AdjWiPk : Ellipsoid
    {
        internal Grs1980AdjWiPk()
        {
            this.EquatorialRadius = 6378413.671;
            this.Flattening = 1 / 298.270159910105;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


