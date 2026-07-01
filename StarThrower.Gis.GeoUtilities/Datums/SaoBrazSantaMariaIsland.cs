// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SAO BRAZ, Santa Maria Is.
    /// Ellipsoid: International_1924,  DeltaX: -203,  SigmaX: 25,  DeltaY: 141,  SigmaY: 25,  DeltaZ: 53,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 39,  South: 35,  East: -23,  West: -27
    /// </summary>
    public class SaoBrazSantaMariaIsland : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SaoBrazSantaMariaIsland()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -203;
            this.SigmaX = 25;
            this.DeltaY = 141;
            this.SigmaY = 25;
            this.DeltaZ = 53;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 39;
            this.Domain.Left = -27;
            this.Domain.Bottom = 35;
            this.Domain.Right = -23;
        }
    }
}


