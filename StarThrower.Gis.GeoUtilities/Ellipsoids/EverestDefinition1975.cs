// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_Definition_1975
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6377299.151, Flattening: 1 / 300.8017255
    /// </summary>
    public class EverestDefinition1975 : Ellipsoid
    {
        internal EverestDefinition1975()
        {
            this.EquatorialRadius = 6377299.151;
            this.Flattening = 1 / 300.8017255;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


