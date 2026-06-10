// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: No Equivalent
    /// NGIA GeoTrans: Hough 1960 [HO]
    /// EquatorialRadius: 6378270.0, Flattening: 1 / 297.0
    /// </summary>
    public class Hough1960 : Ellipsoid
    {
        internal Hough1960()
        {
            this.EquatorialRadius = 6378270.0;
            this.Flattening = 1 / 297.0;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


