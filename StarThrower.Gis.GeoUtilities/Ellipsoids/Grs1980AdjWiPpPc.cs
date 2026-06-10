// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_PP_PC
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378381.271, Flattening: 1 / 298.268644807185
    /// </summary>
    public class Grs1980AdjWiPpPc : Ellipsoid
    {
        internal Grs1980AdjWiPpPc()
        {
            this.EquatorialRadius = 6378381.271;
            this.Flattening = 1 / 298.268644807185;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


