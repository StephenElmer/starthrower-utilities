// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Indonesian
    /// NGIA GeoTrans: Indonesian 1974 [ID]
    /// EquatorialRadius: 6378160.0, Flattening: 1 / 298.247
    /// </summary>
    public class Indonesian : Ellipsoid
    {
        internal Indonesian()
        {
            this.EquatorialRadius = 6378160.0;
            this.Flattening = 1 / 298.247;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


