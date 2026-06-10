// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: ATS_1977
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378135.0, Flattening: 1 / 298.257
    /// </summary>
    public class Ats1977 : Ellipsoid
    {
        internal Ats1977()
        {
            this.EquatorialRadius = 6378135.0;
            this.Flattening = 1 / 298.257;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


