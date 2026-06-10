// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Struve_1860
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378298.3, Flattening: 1 / 294.73
    /// </summary>
    public class Struve1860 : Ellipsoid
    {
        internal Struve1860()
        {
            this.EquatorialRadius = 6378298.3;
            this.Flattening = 1 / 294.73;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


