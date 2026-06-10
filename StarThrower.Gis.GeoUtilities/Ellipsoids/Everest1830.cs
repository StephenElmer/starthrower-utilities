// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_1830
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6377299.36, Flattening: 1 / 300.8017
    /// </summary>
    public class Everest1830 : Ellipsoid
    {
        internal Everest1830()
        {
            this.EquatorialRadius = 6377299.36;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


