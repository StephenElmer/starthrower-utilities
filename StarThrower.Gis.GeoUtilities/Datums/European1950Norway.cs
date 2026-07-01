// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Norway and Finland
    /// Ellipsoid: International_1924,  DeltaX: -87,  SigmaX: 3,  DeltaY: -95,  SigmaY: 5,  DeltaZ: -120,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 80,  South: 52,  East: 38,  West: -2
    /// </summary>
    public class European1950Norway : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Norway()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -87;
            this.SigmaX = 3;
            this.DeltaY = -95;
            this.SigmaY = 5;
            this.DeltaZ = -120;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 80;
            this.Domain.Left = -2;
            this.Domain.Bottom = 52;
            this.Domain.Right = 38;
        }
    }
}


