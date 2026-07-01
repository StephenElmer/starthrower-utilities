// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: M'PORALOKO, Gabon
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -74,  SigmaX: 25,  DeltaY: -130,  SigmaY: 25,  DeltaZ: 42,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 8,  South: -10,  East: 20,  West: 3
    /// </summary>
    public class MPoralokoGabon : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MPoralokoGabon()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -74;
            this.SigmaX = 25;
            this.DeltaY = -130;
            this.SigmaY = 25;
            this.DeltaZ = 42;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 8;
            this.Domain.Left = 3;
            this.Domain.Bottom = -10;
            this.Domain.Right = 20;
        }
    }
}


