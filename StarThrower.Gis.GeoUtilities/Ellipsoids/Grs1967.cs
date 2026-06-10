// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: GRS_1967
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378160.0, Flattening: 1 / 298.247167427
    /// </summary>
    public class Grs1967 : Ellipsoid
    {
        internal Grs1967()
        {
            this.EquatorialRadius = 6378160.0;
            this.Flattening = 1 / 298.247167427;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


