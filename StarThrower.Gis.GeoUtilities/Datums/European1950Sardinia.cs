// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Sardinia(Italy)
    /// Ellipsoid: International_1924,  DeltaX: -97,  SigmaX: 25,  DeltaY: -103,  SigmaY: 25,  DeltaZ: -120,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 43,  South: 37,  East: 12,  West: 6
    /// </summary>
    public class European1950Sardinia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Sardinia()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -97;
            this.SigmaX = 25;
            this.DeltaY = -103;
            this.SigmaY = 25;
            this.DeltaZ = -120;
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


