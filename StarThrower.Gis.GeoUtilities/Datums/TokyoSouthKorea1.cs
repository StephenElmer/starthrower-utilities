// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TOKYO, South Korea
    /// Ellipsoid: Bessel_1841,  DeltaX: -146,  SigmaX: 8,  DeltaY: 507,  SigmaY: 5,  DeltaZ: 687,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 45,  South: 27,  East: 139,  West: 120
    /// </summary>
    public class TokyoSouthKorea1 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TokyoSouthKorea1()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -146;
            this.SigmaX = 8;
            this.DeltaY = 507;
            this.SigmaY = 5;
            this.DeltaZ = 687;
            this.SigmaZ = 8;
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


