// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PICO DE LAS NIEVES, Canary Is.
    /// Ellipsoid: International_1924,  DeltaX: -307,  SigmaX: 25,  DeltaY: -92,  SigmaY: 25,  DeltaZ: 127,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 31,  South: 26,  East: -12,  West: -20
    /// </summary>
    public class CanaryIslands : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal CanaryIslands()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -307;
            this.SigmaX = 25;
            this.DeltaY = -92;
            this.SigmaY = 25;
            this.DeltaZ = 127;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 31;
            this.Domain.Left = -20;
            this.Domain.Bottom = 26;
            this.Domain.Right = -12;
        }
    }
}


