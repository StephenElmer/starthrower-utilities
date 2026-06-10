// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1980
    /// NGIA GeoTrans: GRS 80 [RF]
    /// EquatorialRadius: 6378137.0, Flattening: 1 / 298.257222101
    /// </summary>
    public class Grs1980 : Ellipsoid
    {
        internal Grs1980()
        {
            this.EquatorialRadius = 6378137.0;
            this.Flattening = 1 / 298.257222101;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


