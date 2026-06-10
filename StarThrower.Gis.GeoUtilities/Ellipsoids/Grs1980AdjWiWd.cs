// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_WD
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378437.651, Flattening: 1 / 298.271281273316
    /// </summary>
    public class Grs1980AdjWiWd : Ellipsoid
    {
        internal Grs1980AdjWiWd()
        {
            this.EquatorialRadius = 6378437.651;
            this.Flattening = 1 / 298.271281273316;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


