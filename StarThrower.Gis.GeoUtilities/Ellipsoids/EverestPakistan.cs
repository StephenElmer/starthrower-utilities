// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: No Equivalent
    /// NGIA GeoTrans: Everest (Pakistan) [EF]
    /// EquatorialRadius: 6377309.613, Flattening: 1 / 300.8017
    /// </summary>
    public class EverestPakistan : Ellipsoid
    {
        internal EverestPakistan()
        {
            this.EquatorialRadius = 6377309.613;
            this.Flattening = 1 / 300.8017;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


