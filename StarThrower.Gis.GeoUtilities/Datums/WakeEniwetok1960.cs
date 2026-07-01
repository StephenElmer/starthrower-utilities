// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: WAKE-ENIWETOK 1960
    /// Ellipsoid: Hough_1960,  DeltaX: 102,  SigmaX: 3,  DeltaY: 52,  SigmaY: 3,  DeltaZ: -38,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 16,  South: 1,  East: 175,  West: 159
    /// </summary>
    public class WakeEniwetok1960 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal WakeEniwetok1960()
        {
            this.Ellipsoid = new Ellipsoids.Hough1960();
            this.DeltaX = 102;
            this.SigmaX = 3;
            this.DeltaY = 52;
            this.SigmaY = 3;
            this.DeltaZ = -38;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 16;
            this.Domain.Left = 159;
            this.Domain.Bottom = 1;
            this.Domain.Right = 175;
        }
    }
}


