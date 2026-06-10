// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_1830_Modified
    /// NGIA GeoTrans: Everest 1948(w.Mals. and Sing.) [EE]
    /// EquatorialRadius: 6377304.063, Flattening: 1 / 300.8017
    /// </summary>
    public class Everest1830Modified : Ellipsoid
    {
        internal Everest1830Modified()
        {
            this.EquatorialRadius = 6377304.063;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


