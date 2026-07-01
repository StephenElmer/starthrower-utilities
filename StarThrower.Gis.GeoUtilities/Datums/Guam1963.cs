// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: GUAM 1963
    /// Ellipsoid: Clarke_1866,  DeltaX: -100,  SigmaX: 3,  DeltaY: -248,  SigmaY: 3,  DeltaZ: 259,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 15,  South: 12,  East: 146,  West: 143
    /// </summary>
    public class Guam1963 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Guam1963()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -100;
            this.SigmaX = 3;
            this.DeltaY = -248;
            this.SigmaY = 3;
            this.DeltaZ = 259;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 15;
            this.Domain.Left = 143;
            this.Domain.Bottom = 12;
            this.Domain.Right = 146;
        }
    }
}


