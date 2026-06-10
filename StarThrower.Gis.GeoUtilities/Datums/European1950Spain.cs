// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Portugal and Spain
    /// Ellipsoid: International_1924,  DeltaX: -84,  SigmaX: 5,  DeltaY: -107,  SigmaY: 6,  DeltaZ: -120,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 49,  South: 30,  East: 10,  West: -15
    /// </summary>
    public class European1950Spain : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Spain()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -84;
            this.SigmaX = 5;
            this.DeltaY = -107;
            this.SigmaY = 6;
            this.DeltaZ = -120;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 49;
            this.Domain.Left = -15;
            this.Domain.Bottom = 30;
            this.Domain.Right = 10;
        }
    }
}


