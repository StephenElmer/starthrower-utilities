// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: VOIROL 1960, Algeria
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -123,  SigmaX: 25,  DeltaY: -206,  SigmaY: 25,  DeltaZ: 219,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 43,  South: 13,  East: 18,  West: -15
    /// </summary>
    public class Algeria1960 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Algeria1960()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -123;
            this.SigmaX = 25;
            this.DeltaY = -206;
            this.SigmaY = 25;
            this.DeltaZ = 219;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 43;
            this.Domain.Left = -15;
            this.Domain.Bottom = 13;
            this.Domain.Right = 18;
        }
    }
}


