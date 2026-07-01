// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: S-42 (PK42) Former Czechoslov.
    /// Ellipsoid: Krasovsky_1940,  DeltaX: 26,  SigmaX: 3,  DeltaY: -121,  SigmaY: 3,  DeltaZ: -78,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 57,  South: 42,  East: 28,  West: 6
    /// </summary>
    public class Czechoslov1942 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Czechoslov1942()
        {
            this.Ellipsoid = new Ellipsoids.Krasovsky1940();
            this.DeltaX = 26;
            this.SigmaX = 3;
            this.DeltaY = -121;
            this.SigmaY = 3;
            this.DeltaZ = -78;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 57;
            this.Domain.Left = 6;
            this.Domain.Bottom = 42;
            this.Domain.Right = 28;
        }
    }
}


