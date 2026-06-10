// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Krasovsky_1940
    /// NGIA GeoTrans: Krassovsky 1940 [KA]
    /// EquatorialRadius: 6378245.0, Flattening: 1 / 298.3
    /// </summary>
    public class Krasovsky1940 : Ellipsoid
    {
        internal Krasovsky1940()
        {
            this.EquatorialRadius = 6378245.0;
            this.Flattening = 1 / 298.3;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


