// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: WAKE ISLAND ASTRO 1952
    /// Ellipsoid: International_1924,  DeltaX: 276,  SigmaX: 25,  DeltaY: -57,  SigmaY: 25,  DeltaZ: 149,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 21,  South: 17,  East: 168,  West: 164
    /// </summary>
    public class WakeIsland1952 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal WakeIsland1952()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 276;
            this.SigmaX = 25;
            this.DeltaY = -57;
            this.SigmaY = 25;
            this.DeltaZ = 149;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 21;
            this.Domain.Left = 164;
            this.Domain.Bottom = 17;
            this.Domain.Right = 168;
        }
    }
}


