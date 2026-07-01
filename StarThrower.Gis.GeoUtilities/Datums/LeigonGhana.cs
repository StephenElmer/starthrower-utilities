// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: LEIGON, Ghana
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -130,  SigmaX: 2,  DeltaY: 29,  SigmaY: 3,  DeltaZ: 364,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 17,  South: -1,  East: 7,  West: -9
    /// </summary>
    public class LeigonGhana : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal LeigonGhana()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -130;
            this.SigmaX = 2;
            this.DeltaY = 29;
            this.SigmaY = 3;
            this.DeltaZ = 364;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 17;
            this.Domain.Left = -9;
            this.Domain.Bottom = -1;
            this.Domain.Right = 7;
        }
    }
}


