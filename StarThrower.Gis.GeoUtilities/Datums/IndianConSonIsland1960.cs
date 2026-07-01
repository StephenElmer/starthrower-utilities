// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN 1960, Con Son Island
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 182,  SigmaX: 25,  DeltaY: 915,  SigmaY: 25,  DeltaZ: 344,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 11,  South: 6,  East: 109,  West: 104
    /// </summary>
    public class IndianConSonIsland1960 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianConSonIsland1960()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 182;
            this.SigmaX = 25;
            this.DeltaY = 915;
            this.SigmaY = 25;
            this.DeltaZ = 344;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 11;
            this.Domain.Left = 104;
            this.Domain.Bottom = 6;
            this.Domain.Right = 109;
        }
    }
}


