// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_6
    /// NGIA GeoTrans: ADINDAN, Senegal
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -128,  SigmaX: 25,  DeltaY: -18,  SigmaY: 25,  DeltaZ: 224,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 23,  South: 5,  East: -5,  West: -24
    /// </summary>
    public class AdindanSenegal : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanSenegal()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -128;
            this.SigmaX = 25;
            this.DeltaY = -18;
            this.SigmaY = 25;
            this.DeltaZ = 224;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 23;
            this.Domain.Left = -24;
            this.Domain.Bottom = 5;
            this.Domain.Right = -5;
        }
    }
}


