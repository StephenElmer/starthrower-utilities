// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Colombia
    /// Ellipsoid: South_American_1969,  DeltaX: -44,  SigmaX: 6,  DeltaY: 6,  SigmaY: 6,  DeltaZ: -36,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 16,  South: -10,  East: -61,  West: -85
    /// </summary>
    public class SAmerican1969Colombia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Colombia()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -44;
            this.SigmaX = 6;
            this.DeltaY = 6;
            this.SigmaY = 6;
            this.DeltaZ = -36;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 16;
            this.Domain.Left = -85;
            this.Domain.Bottom = -10;
            this.Domain.Right = -61;
        }
    }
}


