// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: WGS_1972
    /// NGIA GeoTrans: WGS 72 [WD]
    /// EquatorialRadius: 6378135.0, Flattening: 1 / 298.26
    /// </summary>
    public class Wgs1972 : Ellipsoid
    {
        internal Wgs1972()
        {
            this.EquatorialRadius = 6378135.0;
            this.Flattening = 1 / 298.26;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


