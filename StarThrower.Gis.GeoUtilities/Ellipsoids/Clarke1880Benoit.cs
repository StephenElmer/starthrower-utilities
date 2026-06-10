// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1880_Benoit
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378300.79, Flattening: 1 / 293.466234571
    /// </summary>
    public class Clarke1880Benoit : Ellipsoid
    {
        internal Clarke1880Benoit()
        {
            this.EquatorialRadius = 6378300.79;
            this.Flattening = 1 / 293.466234571;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


