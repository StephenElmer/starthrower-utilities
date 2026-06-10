// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Xian_1980
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378140.0, Flattening: 1 / 298.257
    /// </summary>
    public class Xian1980 : Ellipsoid
    {
        internal Xian1980()
        {
            this.EquatorialRadius = 6378140.0;
            this.Flattening = 1 / 298.257;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


