// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ASTRO TERN ISLAND (FRIG) 1961
    /// Ellipsoid: International_1924,  DeltaX: 114,  SigmaX: 25,  DeltaY: -116,  SigmaY: 25,  DeltaZ: -333,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 26,  South: 22,  East: -164,  West: -168
    /// </summary>
    public class AstroTernIsland1961 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AstroTernIsland1961()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 114;
            this.SigmaX = 25;
            this.DeltaY = -116;
            this.SigmaY = 25;
            this.DeltaZ = -333;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 26;
            this.Domain.Left = -168;
            this.Domain.Bottom = 22;
            this.Domain.Right = -164;
        }
    }
}


