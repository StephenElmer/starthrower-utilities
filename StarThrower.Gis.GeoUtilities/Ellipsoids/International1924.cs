// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: International_1924
    /// NGIA GeoTrans: International 1924 [IN]
    /// EquatorialRadius: 6378388.0, Flattening: 1 / 297.0
    /// </summary>
    public class International1924 : Ellipsoid
    {
        internal International1924()
        {
            this.EquatorialRadius = 6378388.0;
            this.Flattening = 1 / 297.0;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


