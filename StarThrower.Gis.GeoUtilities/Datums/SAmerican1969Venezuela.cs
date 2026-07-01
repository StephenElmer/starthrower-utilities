// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Venezuela
    /// Ellipsoid: South_American_1969,  DeltaX: -45,  SigmaX: 3,  DeltaY: 8,  SigmaY: 6,  DeltaZ: -33,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 18,  South: -5,  East: -54,  West: -79
    /// </summary>
    public class SAmerican1969Venezuela : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Venezuela()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -45;
            this.SigmaX = 3;
            this.DeltaY = 8;
            this.SigmaY = 6;
            this.DeltaZ = -33;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 18;
            this.Domain.Left = -79;
            this.Domain.Bottom = -5;
            this.Domain.Right = -54;
        }
    }
}


