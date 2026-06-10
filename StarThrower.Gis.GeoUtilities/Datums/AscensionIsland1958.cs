// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ASCENSION ISLAND 1958
    /// Ellipsoid: International_1924,  DeltaX: -205,  SigmaX: 25,  DeltaY: 107,  SigmaY: 25,  DeltaZ: 53,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -6,  South: -9,  East: -13,  West: -16
    /// </summary>
    public class AscensionIsland1958 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AscensionIsland1958()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -205;
            this.SigmaX = 25;
            this.DeltaY = 107;
            this.SigmaY = 25;
            this.DeltaZ = 53;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -6;
            this.Domain.Left = -16;
            this.Domain.Bottom = -9;
            this.Domain.Right = -13;
        }
    }
}


