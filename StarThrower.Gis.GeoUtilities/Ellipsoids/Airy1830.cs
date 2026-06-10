// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Airy_1830
    /// NGIA GeoTrans: Airy 1830 [AA]
    /// EquatorialRadius: 6377563.396, Flattening: 1 / 299.3249646
    /// </summary>
    public class Airy1830 : Ellipsoid
    {
        internal Airy1830()
        {
            this.EquatorialRadius = 6377563.396;
            this.Flattening = 1 / 299.3249646;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


