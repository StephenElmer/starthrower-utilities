// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Iraq, Israel
    /// Ellipsoid: International_1924,  DeltaX: -103,  SigmaX: -1,  DeltaY: -106,  SigmaY: -1,  DeltaZ: -141,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 48,  South: 20,  East: 60,  West: 24
    /// </summary>
    public class European1950IraqIsreal : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950IraqIsreal()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -103;
            this.SigmaX = -1;
            this.DeltaY = -106;
            this.SigmaY = -1;
            this.DeltaZ = -141;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 48;
            this.Domain.Left = 24;
            this.Domain.Bottom = 20;
            this.Domain.Right = 60;
        }
    }
}


