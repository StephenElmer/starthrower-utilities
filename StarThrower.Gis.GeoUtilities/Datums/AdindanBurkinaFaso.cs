// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_2
    /// NGIA GeoTrans: ADINDAN, Burkina Faso
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -118,  SigmaX: 25,  DeltaY: -14,  SigmaY: 25,  DeltaZ: 218,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 22,  South: 4,  East: 8,  West: -12
    /// </summary>
    public class AdindanBurkinaFaso : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanBurkinaFaso()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -118;
            this.SigmaX = 25;
            this.DeltaY = -14;
            this.SigmaY = 25;
            this.DeltaZ = 218;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 22;
            this.Domain.Left = -12;
            this.Domain.Bottom = 4;
            this.Domain.Right = 8;
        }
    }
}


