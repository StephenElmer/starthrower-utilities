// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN 1975, Thailand
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 210,  SigmaX: 3,  DeltaY: 814,  SigmaY: 2,  DeltaZ: 289,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 27,  South: 0,  East: 111,  West: 91
    /// </summary>
    public class IndianThailand19751 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianThailand19751()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 210;
            this.SigmaX = 3;
            this.DeltaY = 814;
            this.SigmaY = 2;
            this.DeltaZ = 289;
            this.SigmaZ = 3;
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


