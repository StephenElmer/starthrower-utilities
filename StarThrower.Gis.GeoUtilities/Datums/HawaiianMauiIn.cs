// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (IN), Maui
    /// Ellipsoid: International_1924,  DeltaX: 205,  SigmaX: 25,  DeltaY: -233,  SigmaY: 25,  DeltaZ: -355,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 23,  South: 19,  East: -154,  West: -158
    /// </summary>
    public class HawaiianMauiIn : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianMauiIn()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = 205;
            this.SigmaX = 25;
            this.DeltaY = -233;
            this.SigmaY = 25;
            this.DeltaZ = -355;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 23;
            this.Domain.Left = -158;
            this.Domain.Bottom = 19;
            this.Domain.Right = -154;
        }
    }
}


