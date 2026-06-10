// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: No Equivalent
    /// NGIA GeoTrans: Mod. Fischer 1960(South Asia) [FA]
    /// EquatorialRadius: 6378155.0, Flattening: 1 / 298.3
    /// </summary>
    public class Fischer1960Modified : Ellipsoid
    {
        internal Fischer1960Modified()
        {
            this.EquatorialRadius = 6378155.0;
            this.Flattening = 1 / 298.3;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


