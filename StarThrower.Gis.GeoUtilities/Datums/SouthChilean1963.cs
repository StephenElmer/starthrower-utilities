// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROVISIONAL SOUTH CHILEAN 1963
    /// Ellipsoid: International_1924,  DeltaX: 16,  SigmaX: 25,  DeltaY: 196,  SigmaY: 25,  DeltaZ: 93,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -25,  South: -64,  East: -60,  West: -83
    /// </summary>
    public class SouthChilean1963 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SouthChilean1963()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 16;
            this.SigmaX = 25;
            this.DeltaY = 196;
            this.SigmaY = 25;
            this.DeltaZ = 93;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -25;
            this.Domain.Left = -83;
            this.Domain.Bottom = -64;
            this.Domain.Right = -60;
        }
    }
}


