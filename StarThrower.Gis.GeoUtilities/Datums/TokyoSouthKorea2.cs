// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TOKYO, South Korea
    /// Ellipsoid: Bessel_1841,  DeltaX: -147,  SigmaX: 2,  DeltaY: 506,  SigmaY: 2,  DeltaZ: 687,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 45,  South: 27,  East: 139,  West: 120
    /// </summary>
    public class TokyoSouthKorea2 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoSouthKorea2()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -147;
            this.SigmaX = 2;
            this.DeltaY = 506;
            this.SigmaY = 2;
            this.DeltaZ = 687;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 45;
            this.Domain.Left = 120;
            this.Domain.Bottom = 27;
            this.Domain.Right = 139;
        }
    }
}


