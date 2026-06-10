// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_Definition_1967
    /// NGIA GeoTrans: Everest (E. Malasia, Brunei) [EB]
    /// EquatorialRadius: 6377298.556, Flattening: 1 / 300.8017
    /// </summary>
    public class EverestDefinition1967 : Ellipsoid
    {
        internal EverestDefinition1967()
        {
            this.EquatorialRadius = 6377298.556;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


