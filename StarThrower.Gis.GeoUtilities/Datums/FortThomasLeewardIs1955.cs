// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: FORT THOMAS 1955, Leeward Is.
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -7,  SigmaX: 25,  DeltaY: 215,  SigmaY: 25,  DeltaZ: 225,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: 16,  East: -61,  West: -64
    /// </summary>
    public class FortThomasLeewardIs1955 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal FortThomasLeewardIs1955()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -7;
            this.SigmaX = 25;
            this.DeltaY = 215;
            this.SigmaY = 25;
            this.DeltaZ = 225;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = -64;
            this.Domain.Bottom = 16;
            this.Domain.Right = -61;
        }
    }
}


