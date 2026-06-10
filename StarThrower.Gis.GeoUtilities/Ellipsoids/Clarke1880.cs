// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1880
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378249.138, Flattening: 1 / 293.466307656
    /// </summary>
    public class Clarke1880 : Ellipsoid
    {
        internal Clarke1880()
        {
            this.EquatorialRadius = 6378249.138;
            this.Flattening = 1 / 293.466307656;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


