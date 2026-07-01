// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: CHUA ASTRO, Paraguay
    /// Ellipsoid: International_1924,  DeltaX: -134,  SigmaX: 6,  DeltaY: 229,  SigmaY: 9,  DeltaZ: -29,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -14,  South: -33,  East: -49,  West: -69
    /// </summary>
    public class ChuaAstroParaguay : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal ChuaAstroParaguay()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -134;
            this.SigmaX = 6;
            this.DeltaY = 229;
            this.SigmaY = 9;
            this.DeltaZ = -29;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -14;
            this.Domain.Left = -69;
            this.Domain.Bottom = -33;
            this.Domain.Right = -49;
        }
    }
}


