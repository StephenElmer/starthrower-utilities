// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1858
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378293.639, Flattening: 1 / 294.260676369
    /// </summary>
    public class Clarke1858 : Ellipsoid
    {
        internal Clarke1858()
        {
            this.EquatorialRadius = 6378293.639;
            this.Flattening = 1 / 294.260676369;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


