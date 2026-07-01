// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Mean
    /// Ellipsoid: South_American_1969,  DeltaX: -57,  SigmaX: 15,  DeltaY: 1,  SigmaY: 6,  DeltaZ: -41,  SigmaZ: 9,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -50,  South: -65,  East: -25,  West: -90
    /// </summary>
    public class SAmerican1969Mean : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Mean()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -57;
            this.SigmaX = 15;
            this.DeltaY = 1;
            this.SigmaY = 6;
            this.DeltaZ = -41;
            this.SigmaZ = 9;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -50;
            this.Domain.Left = -90;
            this.Domain.Bottom = -65;
            this.Domain.Right = -25;
        }
    }
}


