// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Ellipsoids
{
    /// <summary>
    /// ESRI ArcIMS: Airy_Modified
    /// NGIA GeoTrans: Modified Airy [AM]
    /// EquatorialRadius: 6377340.189, Flattening: 1 / 299.3249646
    /// </summary>
    public class AiryModified : Ellipsoid
    {
        internal AiryModified()
        {
            this.EquatorialRadius = 6377340.189;
            this.Flattening = 1 / 299.3249646;
            this.PolarRadius = this.EquatorialRadius - (this.Flattening * this.EquatorialRadius);
        }
    }
}


