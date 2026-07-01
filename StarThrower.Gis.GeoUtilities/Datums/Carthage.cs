// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Carthage_To_WGS_1984
    /// NGIA GeoTrans: CARTHAGE, Tunisia
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -263,  SigmaX: 6,  DeltaY: 6,  SigmaY: 9,  DeltaZ: 431,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 43,  South: 24,  East: 18,  West: 2
    /// </summary>
    public class Carthage : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Carthage()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -263;
            this.SigmaX = 6;
            this.DeltaY = 6;
            this.SigmaY = 9;
            this.DeltaZ = 431;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 43;
            this.Domain.Left = 2;
            this.Domain.Bottom = 24;
            this.Domain.Right = 18;
        }
    }
}


