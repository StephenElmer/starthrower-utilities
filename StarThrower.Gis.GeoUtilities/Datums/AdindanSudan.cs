// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_7
    /// NGIA GeoTrans: ADINDAN, Sudan
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -161,  SigmaX: 3,  DeltaY: -14,  SigmaY: 5,  DeltaZ: 205,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 31,  South: -3,  East: 45,  West: 15
    /// </summary>
    public class AdindanSudan : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanSudan()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -161;
            this.SigmaX = 3;
            this.DeltaY = -14;
            this.SigmaY = 5;
            this.DeltaZ = 205;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 31;
            this.Domain.Left = 15;
            this.Domain.Bottom = -3;
            this.Domain.Right = 45;
        }
    }
}


