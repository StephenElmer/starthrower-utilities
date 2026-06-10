// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: S-42 (PULKOVO 1942), Romania
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 28,  SigmaX: 3,  DeltaY: -121,  SigmaY: 5,  DeltaZ: -77,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 54,  South: 38,  East: 35,  West: 15
    /// </summary>
    public class Romania1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Romania1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 28;
            this.SigmaX = 3;
            this.DeltaY = -121;
            this.SigmaY = 5;
            this.DeltaZ = -77;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 54;
            this.Domain.Left = 15;
            this.Domain.Bottom = 38;
            this.Domain.Right = 35;
        }
    }
}


