// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Bolivia
    /// Ellipsoid: South_American_1969,  DeltaX: -61,  SigmaX: 15,  DeltaY: 2,  SigmaY: 15,  DeltaZ: -48,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -28,  East: -51,  West: -75
    /// </summary>
    public class SAmerican1969Bolivia : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Bolivia()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -61;
            this.SigmaX = 15;
            this.DeltaY = 2;
            this.SigmaY = 15;
            this.DeltaZ = -48;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = -75;
            this.Domain.Bottom = -28;
            this.Domain.Right = -51;
        }
    }
}


