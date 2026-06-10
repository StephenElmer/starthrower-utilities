// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1880_IGN
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378249.2, Flattening: 1 / 293.46602
    /// </summary>
    public class Clarke1880Ign : Ellipsoid
    {
        internal Clarke1880Ign()
        {
            this.EquatorialRadius = 6378249.2;
            this.Flattening = 1 / 293.46602;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


