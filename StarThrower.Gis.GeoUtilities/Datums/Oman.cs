// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OMAN
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -346,  SigmaX: 3,  DeltaY: -1,  SigmaY: 3,  DeltaZ: 224,  SigmaZ: 9,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 32,  South: 10,  East: 65,  West: 46
    /// </summary>
    public class Oman : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Oman()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -346;
            this.SigmaX = 3;
            this.DeltaY = -1;
            this.SigmaY = 3;
            this.DeltaZ = 224;
            this.SigmaZ = 9;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 32;
            this.Domain.Left = 46;
            this.Domain.Bottom = 10;
            this.Domain.Right = 65;
        }
    }
}


