// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: MASSAWA, Ethiopia
    /// Ellipsoid: Bessel_1841,  DeltaX: 639,  SigmaX: 25,  DeltaY: 405,  SigmaY: 25,  DeltaZ: 60,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 25,  South: 7,  East: 53,  West: 37
    /// </summary>
    public class MassawaEthiopia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MassawaEthiopia()
        {
            this.Ellipsoid = new Ellipsoids.Bessel1841();
            this.DeltaX = 639;
            this.SigmaX = 25;
            this.DeltaY = 405;
            this.SigmaY = 25;
            this.DeltaZ = 60;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 25;
            this.Domain.Left = 37;
            this.Domain.Bottom = 7;
            this.Domain.Right = 53;
        }
    }
}


