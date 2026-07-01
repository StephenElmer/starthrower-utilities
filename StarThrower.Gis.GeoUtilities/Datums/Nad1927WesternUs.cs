// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Western US
    /// Ellipsoid: Clarke_1866,  DeltaX: -8,  SigmaX: 5,  DeltaY: 159,  SigmaY: 3,  DeltaZ: 175,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 55,  South: 19,  East: -87,  West: -132
    /// </summary>
    public class Nad1927WesternUs : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927WesternUs()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -8;
            this.SigmaX = 5;
            this.DeltaY = 159;
            this.SigmaY = 3;
            this.DeltaZ = 175;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 55;
            this.Domain.Left = -132;
            this.Domain.Bottom = 19;
            this.Domain.Right = -87;
        }
    }
}


