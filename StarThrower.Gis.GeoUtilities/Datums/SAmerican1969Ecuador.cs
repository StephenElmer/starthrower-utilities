// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Ecuador
    /// Ellipsoid: South_American_1969,  DeltaX: -48,  SigmaX: 3,  DeltaY: 3,  SigmaY: 3,  DeltaZ: -44,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 7,  South: -11,  East: -70,  West: -85
    /// </summary>
    public class SAmerican1969Ecuador : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Ecuador()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -48;
            this.SigmaX = 3;
            this.DeltaY = 3;
            this.SigmaY = 3;
            this.DeltaZ = -44;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 7;
            this.Domain.Left = -85;
            this.Domain.Bottom = -11;
            this.Domain.Right = -70;
        }
    }
}


