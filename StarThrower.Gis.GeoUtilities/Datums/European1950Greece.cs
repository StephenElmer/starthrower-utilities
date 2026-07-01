// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Greece
    /// Ellipsoid: International_1924,  DeltaX: -84,  SigmaX: 25,  DeltaY: -95,  SigmaY: 25,  DeltaZ: -130,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 48,  South: 30,  East: 34,  West: 14
    /// </summary>
    public class European1950Greece : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950Greece()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -84;
            this.SigmaX = 25;
            this.DeltaY = -95;
            this.SigmaY = 25;
            this.DeltaZ = -130;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 48;
            this.Domain.Left = 14;
            this.Domain.Bottom = 30;
            this.Domain.Right = 34;
        }
    }
}


