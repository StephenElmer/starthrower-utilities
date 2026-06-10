// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: CHATHAM ISLAND ASTRO 1971, NZ
    /// Ellipsoid: International_1924,  DeltaX: 175,  SigmaX: 15,  DeltaY: -38,  SigmaY: 15,  DeltaZ: 113,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -42,  South: -46,  East: -174,  West: -180
    /// </summary>
    public class ChathamIslands1979 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal ChathamIslands1979()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 175;
            this.SigmaX = 15;
            this.DeltaY = -38;
            this.SigmaY = 15;
            this.DeltaZ = 113;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -42;
            this.Domain.Left = -180;
            this.Domain.Bottom = -46;
            this.Domain.Right = -174;
        }
    }
}


