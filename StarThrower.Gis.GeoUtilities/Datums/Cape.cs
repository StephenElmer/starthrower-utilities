// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Cape_To_WGS_1984_1
    /// NGIA GeoTrans: CAPE, South Africa
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -136,  SigmaX: 3,  DeltaY: -108,  SigmaY: 6,  DeltaZ: -292,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -15,  South: -43,  East: 40,  West: 10
    /// </summary>
    public class Cape : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Cape()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -136;
            this.SigmaX = 3;
            this.DeltaY = -108;
            this.SigmaY = 6;
            this.DeltaZ = -292;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -15;
            this.Domain.Left = 10;
            this.Domain.Bottom = -43;
            this.Domain.Right = 40;
        }
    }
}


