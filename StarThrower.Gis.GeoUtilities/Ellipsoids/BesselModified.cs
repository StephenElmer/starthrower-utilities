// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Bessel_Modified
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6377492.018, Flattening: 1 / 299.1528128
    /// </summary>
    public class BesselModified : Ellipsoid
    {
        internal BesselModified()
        {
            this.EquatorialRadius = 6377492.018;
            this.Flattening = 1 / 299.1528128;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


