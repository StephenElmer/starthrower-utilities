// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: KUSAIE ASTRO 1951, Caroline Is.
    /// Ellipsoid: International_1924,  DeltaX: 647,  SigmaX: 25,  DeltaY: 1777,  SigmaY: 25,  DeltaZ: -1124,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 12,  South: -1,  East: 167,  West: 134
    /// </summary>
    public class CarolineIs1951 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CarolineIs1951()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 647;
            this.SigmaX = 25;
            this.DeltaY = 1777;
            this.SigmaY = 25;
            this.DeltaZ = -1124;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 12;
            this.Domain.Left = 134;
            this.Domain.Bottom = -1;
            this.Domain.Right = 167;
        }
    }
}


