// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Everest_Adjustment_1937
    /// NGIA GeoTrans: Everest (India 1830) [EA]
    /// EquatorialRadius: 6377276.345, Flattening: 1 / 300.8017
    /// </summary>
    public class EverestAdjustment1937 : Ellipsoid 
    {
        internal EverestAdjustment1937()
        {
            this.EquatorialRadius = 6377276.345;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


