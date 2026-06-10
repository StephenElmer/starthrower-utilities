// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TOKYO, Okinawa
    /// Ellipsoid: Bessel_1841,  DeltaX: -158,  SigmaX: 20,  DeltaY: 507,  SigmaY: 5,  DeltaZ: 676,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 31,  South: 19,  East: 134,  West: 119
    /// </summary>
    public class TokyoOkinawa : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoOkinawa()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -158;
            this.SigmaX = 20;
            this.DeltaY = 507;
            this.SigmaY = 5;
            this.DeltaZ = 676;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 31;
            this.Domain.Left = 119;
            this.Domain.Bottom = 19;
            this.Domain.Right = 134;
        }
    }
}


