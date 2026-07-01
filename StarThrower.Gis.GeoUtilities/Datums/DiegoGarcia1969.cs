// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ISTS 073 ASTRO 1969, Diego Garc
    /// Ellipsoid: International_1924,  DeltaX: 208,  SigmaX: 25,  DeltaY: -435,  SigmaY: 25,  DeltaZ: -229,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -10,  East: 75,  West: 69
    /// </summary>
    public class DiegoGarcia1969 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal DiegoGarcia1969()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 208;
            this.SigmaX = 25;
            this.DeltaY = -435;
            this.SigmaY = 25;
            this.DeltaZ = -229;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = 69;
            this.Domain.Bottom = -10;
            this.Domain.Right = 75;
        }
    }
}


