// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TOKYO, Japan
    /// Ellipsoid: Bessel_1841,  DeltaX: -148,  SigmaX: 8,  DeltaY: 507,  SigmaY: 5,  DeltaZ: 685,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 51,  South: 19,  East: 156,  West: 119
    /// </summary>
    public class TokyoJapan : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoJapan()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -148;
            this.SigmaX = 8;
            this.DeltaY = 507;
            this.SigmaY = 5;
            this.DeltaZ = 685;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 51;
            this.Domain.Left = 119;
            this.Domain.Bottom = 19;
            this.Domain.Right = 156;
        }
    }
}


