// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (IN), Kauai
    /// Ellipsoid: International_1924,  DeltaX: 185,  SigmaX: 20,  DeltaY: -233,  SigmaY: 20,  DeltaZ: -337,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 20,  East: -158,  West: -161
    /// </summary>
    public class HawaiianKauaiIn : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianKauaiIn()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 185;
            this.SigmaX = 20;
            this.DeltaY = -233;
            this.SigmaY = 20;
            this.DeltaZ = -337;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = -161;
            this.Domain.Bottom = 20;
            this.Domain.Right = -158;
        }
    }
}


