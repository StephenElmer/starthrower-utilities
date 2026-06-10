// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Trinidad
    /// Ellipsoid: South_American_1969,  DeltaX: -45,  SigmaX: 25,  DeltaY: 12,  SigmaY: 25,  DeltaZ: -33,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 17,  South: 4,  East: -55,  West: -68
    /// </summary>
    public class SAmerican1969Trinidad : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Trinidad()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -45;
            this.SigmaX = 25;
            this.DeltaY = 12;
            this.SigmaY = 25;
            this.DeltaZ = -33;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 17;
            this.Domain.Left = -68;
            this.Domain.Bottom = 4;
            this.Domain.Right = -55;
        }
    }
}


