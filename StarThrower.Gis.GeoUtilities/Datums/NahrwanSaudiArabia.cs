// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NAHRWAN, Saudi Arabia
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -243,  SigmaX: 20,  DeltaY: -192,  SigmaY: 20,  DeltaZ: 477,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 8,  East: 62,  West: 28
    /// </summary>
    public class NahrwanSaudiArabia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal NahrwanSaudiArabia()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -243;
            this.SigmaX = 20;
            this.DeltaY = -192;
            this.SigmaY = 20;
            this.DeltaZ = 477;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = 28;
            this.Domain.Bottom = 8;
            this.Domain.Right = 62;
        }
    }
}


