// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Guyana
    /// Ellipsoid: South_American_1969,  DeltaX: -53,  SigmaX: 9,  DeltaY: 3,  SigmaY: 5,  DeltaZ: -47,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 14,  South: -4,  East: -51,  West: -67
    /// </summary>
    public class SAmerican1969Guyana : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Guyana()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -53;
            this.SigmaX = 9;
            this.DeltaY = 3;
            this.SigmaY = 5;
            this.DeltaZ = -47;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 14;
            this.Domain.Left = -67;
            this.Domain.Bottom = -4;
            this.Domain.Right = -51;
        }
    }
}


