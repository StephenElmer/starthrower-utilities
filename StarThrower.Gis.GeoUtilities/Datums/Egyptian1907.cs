// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD EGYPTIAN 1907
    /// Ellipsoid: Helmert_1906,  DeltaX: -130,  SigmaX: 3,  DeltaY: 110,  SigmaY: 6,  DeltaZ: -13,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 16,  East: 42,  West: 19
    /// </summary>
    public class Egyptian1907 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Egyptian1907()
        {
            this.Ellipsoid = new Ellipsoids.Helmert1906();
            this.DeltaX = -130;
            this.SigmaX = 3;
            this.DeltaY = 110;
            this.SigmaY = 6;
            this.DeltaZ = -13;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = 19;
            this.Domain.Bottom = 16;
            this.Domain.Right = 42;
        }
    }
}


