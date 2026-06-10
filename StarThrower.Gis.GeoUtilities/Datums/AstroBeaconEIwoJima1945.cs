// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ASTRO BEACON E 1945, Iwo Jima
    /// Ellipsoid: International_1924,  DeltaX: 145,  SigmaX: 25,  DeltaY: 75,  SigmaY: 25,  DeltaZ: -272,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 26,  South: 22,  East: 144,  West: 140
    /// </summary>
    public class AstroBeaconEIwoJima1945 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AstroBeaconEIwoJima1945()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 145;
            this.SigmaX = 25;
            this.DeltaY = 75;
            this.SigmaY = 25;
            this.DeltaZ = -272;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 26;
            this.Domain.Left = 140;
            this.Domain.Bottom = 22;
            this.Domain.Right = 144;
        }
    }
}


