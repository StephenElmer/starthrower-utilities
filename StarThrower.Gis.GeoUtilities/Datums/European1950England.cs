// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, England, Ireland
    /// Ellipsoid: International_1924,  DeltaX: -86,  SigmaX: 3,  DeltaY: -96,  SigmaY: 3,  DeltaZ: -120,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 62,  South: 48,  East: 3,  West: -12
    /// </summary>
    public class European1950England : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950England()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -86;
            this.SigmaX = 3;
            this.DeltaY = -96;
            this.SigmaY = 3;
            this.DeltaZ = -120;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 62;
            this.Domain.Left = -12;
            this.Domain.Bottom = 48;
            this.Domain.Right = 3;
        }
    }
}


