// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EASTER ISLAND 1967
    /// Ellipsoid: International_1924,  DeltaX: 211,  SigmaX: 25,  DeltaY: 147,  SigmaY: 25,  DeltaZ: 111,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -26,  South: -29,  East: -108,  West: -111
    /// </summary>
    public class EasterIsland1967 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal EasterIsland1967()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 211;
            this.SigmaX = 25;
            this.DeltaY = 147;
            this.SigmaY = 25;
            this.DeltaZ = 111;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -26;
            this.Domain.Left = -111;
            this.Domain.Bottom = -29;
            this.Domain.Right = -108;
        }
    }
}


