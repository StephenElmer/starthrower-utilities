// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: No Equivalent
    /// NGIA GeoTrans: Everest 1956 (India) [EC]
    /// EquatorialRadius: 6377301.243, Flattening: 1 / 300.8017
    /// </summary>
    public class Everest1956India : Ellipsoid
    {
        internal Everest1956India()
        {
            this.EquatorialRadius = 6377301.243;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
   }
}


