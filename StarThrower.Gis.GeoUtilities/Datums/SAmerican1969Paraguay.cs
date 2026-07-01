// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SOUTH AMERICAN 1969, Paraguay
    /// Ellipsoid: South_American_1969,  DeltaX: -61,  SigmaX: 15,  DeltaY: 2,  SigmaY: 15,  DeltaZ: -33,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -14,  South: -33,  East: -49,  West: -69
    /// </summary>
    public class SAmerican1969Paraguay : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmerican1969Paraguay()
        {
            this.Ellipsoid = new Ellipsoids.SouthAmerican1969();
            this.DeltaX = -61;
            this.SigmaX = 15;
            this.DeltaY = 2;
            this.SigmaY = 15;
            this.DeltaZ = -33;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -14;
            this.Domain.Left = -69;
            this.Domain.Bottom = -33;
            this.Domain.Right = -49;
        }
    }
}


