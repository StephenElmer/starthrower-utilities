// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Helmert_1906
    /// NGIA GeoTrans: Helmert 1906 [HE]
    /// EquatorialRadius: 6378200.0, Flattening: 1 / 298.3
    /// </summary>
    public class Helmert1906 : Ellipsoid
    {
        internal Helmert1906()
        {
            this.EquatorialRadius = 6378200.0;
            this.Flattening = 1 / 298.3;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


