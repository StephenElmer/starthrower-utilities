// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Bessel_Namibia
    /// NGIA GeoTrans: Bessel 1841 (Namibia) [BN]
    /// EquatorialRadius: 6377483.865, Flattening: 1 / 299.1528128
    /// </summary>
    public class BesselNamibia : Ellipsoid
    {
        internal BesselNamibia()
        {
            this.EquatorialRadius = 6377483.865;
            this.Flattening = 1 / 299.1528128;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


