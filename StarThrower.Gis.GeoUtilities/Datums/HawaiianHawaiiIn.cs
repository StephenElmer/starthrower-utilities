// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (IN), Hawaii
    /// Ellipsoid: International_1924,  DeltaX: 229,  SigmaX: 25,  DeltaY: -222,  SigmaY: 25,  DeltaZ: -348,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 22,  South: 17,  East: -153,  West: -158
    /// </summary>
    public class HawaiianHawaiiIn : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianHawaiiIn()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 229;
            this.SigmaX = 25;
            this.DeltaY = -222;
            this.SigmaY = 25;
            this.DeltaZ = -348;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 22;
            this.Domain.Left = -158;
            this.Domain.Bottom = 17;
            this.Domain.Right = -153;
        }
    }
}


