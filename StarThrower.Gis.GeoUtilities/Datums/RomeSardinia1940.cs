// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ROME 1940, Sardinia
    /// Ellipsoid: International_1924,  DeltaX: -225,  SigmaX: 25,  DeltaY: -65,  SigmaY: 25,  DeltaZ: 9,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 43,  South: 37,  East: 12,  West: 6
    /// </summary>
    public class RomeSardinia1940 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal RomeSardinia1940()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -225;
            this.SigmaX = 25;
            this.DeltaY = -65;
            this.SigmaY = 25;
            this.DeltaZ = 9;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 43;
            this.Domain.Left = 6;
            this.Domain.Bottom = 37;
            this.Domain.Right = 12;
        }
    }
}


