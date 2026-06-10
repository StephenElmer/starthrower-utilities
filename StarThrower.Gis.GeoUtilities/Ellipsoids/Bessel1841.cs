// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Bessel_1841
    /// NGIA GeoTrans: Bessel 1841 [BR]
    /// EquatorialRadius: 6377397.155, Flattening: 1 / 299.1528128
    /// </summary>
    public class Bessel1841 : Ellipsoid
    {
        internal Bessel1841()
        {
            this.EquatorialRadius = 6377397.155;
            this.Flattening = 1 / 299.1528128;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


