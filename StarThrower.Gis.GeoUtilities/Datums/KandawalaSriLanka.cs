// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: KANDAWALA, Sri Lanka
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: -97,  SigmaX: 20,  DeltaY: 787,  SigmaY: 20,  DeltaZ: 86,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 12,  South: 4,  East: 85,  West: 77
    /// </summary>
    public class KandawalaSriLanka : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal KandawalaSriLanka()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = -97;
            this.SigmaX = 20;
            this.DeltaY = 787;
            this.SigmaY = 20;
            this.DeltaZ = 86;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 12;
            this.Domain.Left = 77;
            this.Domain.Bottom = 4;
            this.Domain.Right = 85;
        }
    }
}


