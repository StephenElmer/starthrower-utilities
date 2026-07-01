// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Bolivia
    /// Ellipsoid: International_1924,  DeltaX: -270,  SigmaX: 5,  DeltaY: 188,  SigmaY: 11,  DeltaZ: -388,  SigmaZ: 14,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -28,  East: -51,  West: -75
    /// </summary>
    public class SAmericanBolivia1956 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanBolivia1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -270;
            this.SigmaX = 5;
            this.DeltaY = 188;
            this.SigmaY = 11;
            this.DeltaZ = -388;
            this.SigmaZ = 14;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = -75;
            this.Domain.Bottom = -28;
            this.Domain.Right = -51;
        }
    }
}


