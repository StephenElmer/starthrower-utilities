// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Clarke_1880_Arc
    /// NGIA GeoTrans: No Equivalent
    /// EquatorialRadius: 6378249.145, Flattening: 1 / 293.466307656
    /// </summary>
    public class Clarke1880Arc : Ellipsoid
    {
        internal Clarke1880Arc()
        {
            this.EquatorialRadius = 6378249.145;
            this.Flattening = 1 / 293.466307656;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


