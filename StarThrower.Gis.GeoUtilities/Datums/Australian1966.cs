// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: AUSTRALIAN GEODETIC 1966
    /// Ellipsoid: Australian,  DeltaX: -133,  SigmaX: 3,  DeltaY: -48,  SigmaY: 3,  DeltaZ: 148,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -46,  East: 161,  West: 109
    /// </summary>
    public class Australian1966 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Australian1966()
        {
            this.Ellipsoid = new Ellipsoids.Australian();
            this.DeltaX = -133;
            this.SigmaX = 3;
            this.DeltaY = -48;
            this.SigmaY = 3;
            this.DeltaZ = 148;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = 109;
            this.Domain.Bottom = -46;
            this.Domain.Right = 161;
        }
    }
}


