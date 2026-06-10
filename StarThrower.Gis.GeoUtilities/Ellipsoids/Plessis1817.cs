// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Plessis_1817
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6376523.0, Flattening: 1 / 308.64
    /// </summary>
    public class Plessis1817 : Ellipsoid
    {
        internal Plessis1817()
        {
            this.EquatorialRadius = 6376523.0;
            this.Flattening = 1 / 308.64;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


