// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_Definition_1962
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6377301.243, Flattening: 1 / 300.8017255
    /// </summary>
    public class EverestDefinition1962 : Ellipsoid
    {
        internal EverestDefinition1962()
        {
            this.EquatorialRadius = 6377301.243;
            this.Flattening = 1 / 300.8017255;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


