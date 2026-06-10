// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ESTONIA, 1937
    /// Ellipsoid: Bessel_1841,  DeltaX: 374,  SigmaX: 2,  DeltaY: 150,  SigmaY: 3,  DeltaZ: 588,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 65,  South: 52,  East: 34,  West: 16
    /// </summary>
    public class Estonia1937 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Estonia1937()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 374;
            this.SigmaX = 2;
            this.DeltaY = 150;
            this.SigmaY = 3;
            this.DeltaZ = 588;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 65;
            this.Domain.Left = 16;
            this.Domain.Bottom = 52;
            this.Domain.Right = 34;
        }
    }
}


