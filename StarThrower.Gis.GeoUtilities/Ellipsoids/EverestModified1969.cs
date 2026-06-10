// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_Modified_1969
    /// NGIA GeoTrans: Everest 1969 (West Malasia) [ED]
    /// EquatorialRadius: 6377295.664, Flattening: 1 / 300.8017
    /// </summary>
    public class EverestModified1969 : Ellipsoid
    {
        internal EverestModified1969()
        {
            this.EquatorialRadius = 6377295.664;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


