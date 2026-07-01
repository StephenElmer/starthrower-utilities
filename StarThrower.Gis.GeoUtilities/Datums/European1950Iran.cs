// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Iran
    /// Ellipsoid: International_1924,  DeltaX: -117,  SigmaX: 9,  DeltaY: -132,  SigmaY: 12,  DeltaZ: -164,  SigmaZ: 11,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 47,  South: 19,  East: 69,  West: 37
    /// </summary>
    public class European1950Iran : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Iran()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -117;
            this.SigmaX = 9;
            this.DeltaY = -132;
            this.SigmaY = 12;
            this.DeltaZ = -164;
            this.SigmaZ = 11;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 47;
            this.Domain.Left = 37;
            this.Domain.Bottom = 19;
            this.Domain.Right = 69;
        }
    }
}


