// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Peru
    /// Ellipsoid: South_American_1969,  DeltaX: -58,  SigmaX: 5,  DeltaY: 0,  SigmaY: 5,  DeltaZ: -44,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 5,  South: -24,  East: -63,  West: -87
    /// </summary>
    public class SAmerican1969Peru : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Peru()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -58;
            this.SigmaX = 5;
            this.DeltaY = 0;
            this.SigmaY = 5;
            this.DeltaZ = -44;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 5;
            this.Domain.Left = -87;
            this.Domain.Bottom = -24;
            this.Domain.Right = -63;
        }
    }
}


