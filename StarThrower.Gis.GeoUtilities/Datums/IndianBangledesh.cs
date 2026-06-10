// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: INDIAN, Bangladesh
    /// Ellipsoid: Everest_Adjustment_1937,  DeltaX: 282,  SigmaX: 10,  DeltaY: 726,  SigmaY: 8,  DeltaZ: 254,  SigmaZ: 12,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 33,  South: 15,  East: 100,  West: 80
    /// </summary>
    public class IndianBangledesh : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal IndianBangledesh()
        {
            this.Ellipsoid = new Ellipsoids.EverestAdjustment1937();
            this.DeltaX = 282;
            this.SigmaX = 10;
            this.DeltaY = 726;
            this.SigmaY = 8;
            this.DeltaZ = 254;
            this.SigmaZ = 12;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 33;
            this.Domain.Left = 80;
            this.Domain.Bottom = 15;
            this.Domain.Right = 100;
        }
    }
}


