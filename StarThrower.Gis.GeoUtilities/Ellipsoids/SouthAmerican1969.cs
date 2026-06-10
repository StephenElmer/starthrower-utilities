// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: No Equivalent
    /// NGIA GeoTrans: South American 1969 [SA]
    /// EquatorialRadius: 6378160.0, Flattening: 1 / 298.25 
    /// </summary>
    public class SouthAmerican1969 : Ellipsoid
    {
        internal SouthAmerican1969()
        {
            this.EquatorialRadius = 6378160.0;
            this.Flattening = 1 / 298.25;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
     }
}


