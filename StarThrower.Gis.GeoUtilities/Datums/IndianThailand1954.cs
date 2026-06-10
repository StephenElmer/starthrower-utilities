// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN 1954, Thailand
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 217,  SigmaX: 15,  DeltaY: 823,  SigmaY: 6,  DeltaZ: 299,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 27,  South: 0,  East: 111,  West: 91
    /// </summary>
    public class IndianThailand1954 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianThailand1954()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 217;
            this.SigmaX = 15;
            this.DeltaY = 823;
            this.SigmaY = 6;
            this.DeltaZ = 299;
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


