// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Baltra
    /// Ellipsoid: South_American_1969,  DeltaX: -47,  SigmaX: 25,  DeltaY: 26,  SigmaY: 25,  DeltaZ: -42,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 1,  South: -2,  East: -89,  West: -92
    /// </summary>
    public class SAmerican1969Baltra : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Baltra()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -47;
            this.SigmaX = 25;
            this.DeltaY = 26;
            this.SigmaY = 25;
            this.DeltaZ = -42;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 1;
            this.Domain.Left = -92;
            this.Domain.Bottom = -2;
            this.Domain.Right = -89;
        }
    }
}


