// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_AD_JN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378376.271, Flattening: 1 / 298.268410995005
    /// </summary>
    public class Grs1980AdjWiAdJn : Ellipsoid
    {
        internal Grs1980AdjWiAdJn()
        {
            this.EquatorialRadius = 6378376.271;
            this.Flattening = 1 / 298.268410995005;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


