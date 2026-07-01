// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Brazil
    /// Ellipsoid: South_American_1969,  DeltaX: -60,  SigmaX: 3,  DeltaY: -2,  SigmaY: 5,  DeltaZ: -41,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 9,  South: -39,  East: -29,  West: -80
    /// </summary>
    public class SAmerican1969Brazil : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Brazil()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -60;
            this.SigmaX = 3;
            this.DeltaY = -2;
            this.SigmaY = 5;
            this.DeltaZ = -41;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 9;
            this.Domain.Left = -80;
            this.Domain.Bottom = -39;
            this.Domain.Right = -29;
        }
    }
}


