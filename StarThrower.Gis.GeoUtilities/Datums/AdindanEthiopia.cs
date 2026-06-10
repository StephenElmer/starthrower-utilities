// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_4
    /// NGIA GeoTrans: ADINDAN, Ethiopia
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -165,  SigmaX: 3,  DeltaY: -11,  SigmaY: 3,  DeltaZ: 206,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 25,  South: -3,  East: 50,  West: 26
    /// </summary>
    public class AdindanEthiopia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanEthiopia()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -165;
            this.SigmaX = 3;
            this.DeltaY = -11;
            this.SigmaY = 3;
            this.DeltaZ = 206;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 25;
            this.Domain.Left = 26;
            this.Domain.Bottom = -3;
            this.Domain.Right = 50;
        }
    }
}


