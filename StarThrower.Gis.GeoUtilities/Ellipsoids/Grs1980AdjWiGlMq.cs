// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980_Adj_WI_GL_MQ
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378375.601, Flattening: 1 / 298.268379664173
    /// </summary>
    public class Grs1980AdjWiGlMq : Ellipsoid
    {
        internal Grs1980AdjWiGlMq()
        {
            this.EquatorialRadius = 6378375.601;
            this.Flattening = 1 / 298.268379664173;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


