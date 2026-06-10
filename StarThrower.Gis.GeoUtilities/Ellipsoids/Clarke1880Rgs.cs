// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1880_RGS
    /// NGIA GeoTrans: Clarke 1880 [CD]
    /// EquatorialRadius: 6378249.145, Flattening: 1 / 293.465
    /// </summary>
    public class Clarke1880Rgs : Ellipsoid
    {
        internal Clarke1880Rgs()
        {
            this.EquatorialRadius = 6378249.145;
            this.Flattening = 1 / 293.465;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


