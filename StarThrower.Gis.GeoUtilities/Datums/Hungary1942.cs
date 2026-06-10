// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: S-42 (PULKOVO 1942), Hungary
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 28,  SigmaX: 2,  DeltaY: -121,  SigmaY: 2,  DeltaZ: -77,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 54,  South: 40,  East: 29,  West: 11
    /// </summary>
    public class Hungary1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Hungary1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 28;
            this.SigmaX = 2;
            this.DeltaY = -121;
            this.SigmaY = 2;
            this.DeltaZ = -77;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 54;
            this.Domain.Left = 11;
            this.Domain.Bottom = 40;
            this.Domain.Right = 29;
        }
    }
}


