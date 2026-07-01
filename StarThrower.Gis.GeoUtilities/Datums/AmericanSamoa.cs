// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: American_Samoa_1963_To_WGS_1984
    /// NGIA GeoTrans: AMERICAN SAMOA 1962
    /// Ellipsoid: Clarke_1866,  DeltaX: -115,  SigmaX: 25,  DeltaY: 118,  SigmaY: 25,  DeltaZ: 426,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -9,  South: -19,  East: -165,  West: -174
    /// </summary>
    public class AmericanSamoa : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AmericanSamoa()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -115;
            this.SigmaX = 25;
            this.DeltaY = 118;
            this.SigmaY = 25;
            this.DeltaZ = 426;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -9;
            this.Domain.Left = -174;
            this.Domain.Bottom = -19;
            this.Domain.Right = -165;
        }
    }
}


