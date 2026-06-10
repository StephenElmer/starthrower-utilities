// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NAHRWAN, United Arab Emirates
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -249,  SigmaX: 25,  DeltaY: -156,  SigmaY: 25,  DeltaZ: 381,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 32,  South: 17,  East: 62,  West: 45
    /// </summary>
    public class NahrwanUnitedArabEmirates : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal NahrwanUnitedArabEmirates()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -249;
            this.SigmaX = 25;
            this.DeltaY = -156;
            this.SigmaY = 25;
            this.DeltaZ = 381;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 32;
            this.Domain.Left = 45;
            this.Domain.Bottom = 17;
            this.Domain.Right = 62;
        }
    }
}


