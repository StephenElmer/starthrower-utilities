// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1866
    /// NGIA GeoTrans: Clarke 1866 [CC]
    /// EquatorialRadius: 6378206.4, Flattening: 1 / 294.9786982
    /// </summary>
    public class Clarke1866 : Ellipsoid
    {
        internal Clarke1866()
        {
            this.EquatorialRadius = 6378206.4;
            this.Flattening = 1 / 294.9786982;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


