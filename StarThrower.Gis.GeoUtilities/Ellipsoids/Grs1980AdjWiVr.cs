// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_VR
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378408.941, Flattening: 1 / 298.269938723784
    /// </summary>
    public class Grs1980AdjWiVr : Ellipsoid
    {
        internal Grs1980AdjWiVr()
        {
            this.EquatorialRadius = 6378408.941;
            this.Flattening = 1 / 298.269938723784;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


