// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ASTRO STATION 1952, Marcus Is.
    /// Ellipsoid: International_1924,  DeltaX: 124,  SigmaX: 25,  DeltaY: -234,  SigmaY: 25,  DeltaZ: -25,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 26,  South: 22,  East: 156,  West: 152
    /// </summary>
    public class AstroStationMarcusIs1952 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AstroStationMarcusIs1952()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 124;
            this.SigmaX = 25;
            this.DeltaY = -234;
            this.SigmaY = 25;
            this.DeltaZ = -25;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 26;
            this.Domain.Left = 152;
            this.Domain.Bottom = 22;
            this.Domain.Right = 156;
        }
    }
}


