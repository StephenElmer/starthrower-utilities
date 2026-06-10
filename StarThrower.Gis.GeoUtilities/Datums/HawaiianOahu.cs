// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (IN), Oahu
    /// Ellipsoid: International_1924,  DeltaX: 198,  SigmaX: 10,  DeltaY: -226,  SigmaY: 6,  DeltaZ: -347,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 23,  South: 20,  East: -156,  West: -160
    /// </summary>
    public class HawaiianOahu : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianOahu()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 198;
            this.SigmaX = 10;
            this.DeltaY = -226;
            this.SigmaY = 6;
            this.DeltaZ = -347;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 23;
            this.Domain.Left = -160;
            this.Domain.Bottom = 20;
            this.Domain.Right = -156;
        }
    }
}


