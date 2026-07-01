// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, CONUS
    /// Ellipsoid: Clarke_1866,  DeltaX: -8,  SigmaX: 5,  DeltaY: 160,  SigmaY: 5,  DeltaZ: 176,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 60,  South: 15,  East: -60,  West: -135
    /// </summary>
    public class Nad1927Conus : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Conus()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -8;
            this.SigmaX = 5;
            this.DeltaY = 160;
            this.SigmaY = 5;
            this.DeltaZ = 176;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 60;
            this.Domain.Left = -135;
            this.Domain.Bottom = 15;
            this.Domain.Right = -60;
        }
    }
}


