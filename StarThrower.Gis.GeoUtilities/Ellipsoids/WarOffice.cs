// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: War_Office
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378300.0, Flattening: 1 / 296.0
    /// </summary>
    public class WarOffice : Ellipsoid
    {
        internal WarOffice()
        {
            this.EquatorialRadius = 6378300.0;
            this.Flattening = 1 / 296.0;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


