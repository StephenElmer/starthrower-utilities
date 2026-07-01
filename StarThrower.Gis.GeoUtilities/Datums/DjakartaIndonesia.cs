// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: DJAKARTA, INDONESIA
    /// Ellipsoid: Bessel_1841,  DeltaX: -377,  SigmaX: 3,  DeltaY: 681,  SigmaY: 3,  DeltaZ: -50,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 11,  South: -16,  East: 146,  West: 89
    /// </summary>
    public class DjakartaIndonesia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal DjakartaIndonesia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = -377;
            this.SigmaX = 3;
            this.DeltaY = 681;
            this.SigmaY = 3;
            this.DeltaZ = -50;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 11;
            this.Domain.Left = 89;
            this.Domain.Bottom = -16;
            this.Domain.Right = 146;
        }
    }
}


