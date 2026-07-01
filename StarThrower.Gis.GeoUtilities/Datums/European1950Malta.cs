// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Malta
    /// Ellipsoid: International_1924,  DeltaX: -107,  SigmaX: 25,  DeltaY: -88,  SigmaY: 25,  DeltaZ: -149,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 38,  South: 34,  East: 16,  West: 12
    /// </summary>
    public class European1950Malta : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Malta()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -107;
            this.SigmaX = 25;
            this.DeltaY = -88;
            this.SigmaY = 25;
            this.DeltaZ = -149;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 38;
            this.Domain.Left = 12;
            this.Domain.Bottom = 34;
            this.Domain.Right = 16;
        }
    }
}


