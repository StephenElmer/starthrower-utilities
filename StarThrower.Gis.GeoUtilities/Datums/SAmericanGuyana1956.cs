// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Guyana
    /// Ellipsoid: International_1924,  DeltaX: -298,  SigmaX: 6,  DeltaY: 159,  SigmaY: 14,  DeltaZ: -369,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 14,  South: -4,  East: -51,  West: -67
    /// </summary>
    public class SAmericanGuyana1956 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanGuyana1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -298;
            this.SigmaX = 6;
            this.DeltaY = 159;
            this.SigmaY = 14;
            this.DeltaZ = -369;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 14;
            this.Domain.Left = -67;
            this.Domain.Bottom = -4;
            this.Domain.Right = -51;
        }
    }
}


