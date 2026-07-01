// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: LUZON, Philippines
    /// Ellipsoid: Clarke_1866,  DeltaX: -133,  SigmaX: 8,  DeltaY: -77,  SigmaY: 11,  DeltaZ: -51,  SigmaZ: 9,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 23,  South: 3,  East: 128,  West: 115
    /// </summary>
    public class LuzonPhilippines : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal LuzonPhilippines()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -133;
            this.SigmaX = 8;
            this.DeltaY = -77;
            this.SigmaY = 11;
            this.DeltaZ = -51;
            this.SigmaZ = 9;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 23;
            this.Domain.Left = 115;
            this.Domain.Bottom = 3;
            this.Domain.Right = 128;
        }
    }
}


