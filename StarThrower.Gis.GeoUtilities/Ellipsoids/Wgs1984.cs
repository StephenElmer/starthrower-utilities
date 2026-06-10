// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: WGS_1984
    /// NGIA GeoTrans: WGS 84 [WE]
    /// EquatorialRadius: 6378137.0, Flattening: 1 / 298.257223563
    /// </summary>
    public class Wgs1984 : Ellipsoid
    {
        internal Wgs1984()
        {
            this.EquatorialRadius = 6378137.0;
            this.Flattening = 1 / 298.257223563;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


