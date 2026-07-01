// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN 1975, Thailand
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 209,  SigmaX: 12,  DeltaY: 818,  SigmaY: 10,  DeltaZ: 290,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 27,  South: 0,  East: 111,  West: 91
    /// </summary>
    public class IndianThailand1975 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianThailand1975()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 209;
            this.SigmaX = 12;
            this.DeltaY = 818;
            this.SigmaY = 10;
            this.DeltaZ = 290;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 27;
            this.Domain.Left = 91;
            this.Domain.Bottom = 0;
            this.Domain.Right = 111;
        }
    }
}


