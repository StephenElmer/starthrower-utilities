// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: MINNA, Nigeria
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -92,  SigmaX: 3,  DeltaY: -93,  SigmaY: 6,  DeltaZ: 122,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 21,  South: -1,  East: 20,  West: -4
    /// </summary>
    public class MinnaNigeria : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MinnaNigeria()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -92;
            this.SigmaX = 3;
            this.DeltaY = -93;
            this.SigmaY = 6;
            this.DeltaZ = 122;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 21;
            this.Domain.Left = -4;
            this.Domain.Bottom = -1;
            this.Domain.Right = 20;
        }
    }
}


