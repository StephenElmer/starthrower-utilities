// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_5
    /// NGIA GeoTrans: ADINDAN, Mali
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -123,  SigmaX: 25,  DeltaY: -20,  SigmaY: 25,  DeltaZ: 220,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 31,  South: 3,  East: 11,  West: -20
    /// </summary>
    public class AdindanMali : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanMali()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -123;
            this.SigmaX = 25;
            this.DeltaY = -20;
            this.SigmaY = 25;
            this.DeltaZ = 220;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 31;
            this.Domain.Left = -20;
            this.Domain.Bottom = 3;
            this.Domain.Right = 11;
        }
    }
}


