// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Chile
    /// Ellipsoid: South_American_1969,  DeltaX: -75,  SigmaX: 15,  DeltaY: -1,  SigmaY: 8,  DeltaZ: -44,  SigmaZ: 11,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -12,  South: -64,  East: -60,  West: -83
    /// </summary>
    public class SAmerican1969Chile : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Chile()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -75;
            this.SigmaX = 15;
            this.DeltaY = -1;
            this.SigmaY = 8;
            this.DeltaZ = -44;
            this.SigmaZ = 11;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -12;
            this.Domain.Left = -83;
            this.Domain.Bottom = -64;
            this.Domain.Right = -60;
        }
    }
}


