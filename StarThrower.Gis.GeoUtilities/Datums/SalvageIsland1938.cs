// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SELVAGEM GRANDE 1938, Salvage Is
    /// Ellipsoid: International_1924,  DeltaX: -289,  SigmaX: 25,  DeltaY: -124,  SigmaY: 25,  DeltaZ: 60,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 32,  South: 28,  East: -14,  West: -18
    /// </summary>
    public class SalvageIsland1938 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SalvageIsland1938()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -289;
            this.SigmaX = 25;
            this.DeltaY = -124;
            this.SigmaY = 25;
            this.DeltaZ = 60;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 32;
            this.Domain.Left = -18;
            this.Domain.Bottom = 28;
            this.Domain.Right = -14;
        }
    }
}


