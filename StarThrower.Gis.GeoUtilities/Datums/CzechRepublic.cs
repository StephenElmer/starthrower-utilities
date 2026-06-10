// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: S-JTSK, Czech Republic
    /// Ellipsoid: Bessel_1841,  DeltaX: 589,  SigmaX: 4,  DeltaY: 76,  SigmaY: 2,  DeltaZ: 480,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 56,  South: 43,  East: 28,  West: 6
    /// </summary>
    public class CzechRepublic : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CzechRepublic()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 589;
            this.SigmaX = 4;
            this.DeltaY = 76;
            this.SigmaY = 2;
            this.DeltaZ = 480;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 56;
            this.Domain.Left = 6;
            this.Domain.Bottom = 43;
            this.Domain.Right = 28;
        }
    }
}


