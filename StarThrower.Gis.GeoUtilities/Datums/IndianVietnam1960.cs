// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN 1960, Vietnam 16N
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 198,  SigmaX: 25,  DeltaY: 881,  SigmaY: 25,  DeltaZ: 317,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 30,  South: 2,  East: 115,  West: 101
    /// </summary>
    public class IndianVietnam1960 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianVietnam1960()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 198;
            this.SigmaX = 25;
            this.DeltaY = 881;
            this.SigmaY = 25;
            this.DeltaZ = 317;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 30;
            this.Domain.Left = 101;
            this.Domain.Bottom = 2;
            this.Domain.Right = 115;
        }
    }
}


