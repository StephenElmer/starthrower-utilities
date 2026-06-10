// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Sphere_ARC_INFO
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6370997.0, Flattening: 1 / 0.0
    /// </summary>
    public class SphereArcInfo : Ellipsoid
    {
        internal SphereArcInfo()
        {
            this.EquatorialRadius = 6370997.0;
            this.Flattening = 1 / 0.0;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


