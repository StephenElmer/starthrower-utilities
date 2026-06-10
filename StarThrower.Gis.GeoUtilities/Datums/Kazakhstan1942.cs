// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: S-42 (PK 1942), Kazakhstan
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 15,  SigmaX: 25,  DeltaY: -130,  SigmaY: 25,  DeltaZ: -84,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 62,  South: 35,  East: 93,  West: 41
    /// </summary>
    public class Kazakhstan1942 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Kazakhstan1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 15;
            this.SigmaX = 25;
            this.DeltaY = -130;
            this.SigmaY = 25;
            this.DeltaZ = -84;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 62;
            this.Domain.Left = 41;
            this.Domain.Bottom = 35;
            this.Domain.Right = 93;
        }
    }
}


