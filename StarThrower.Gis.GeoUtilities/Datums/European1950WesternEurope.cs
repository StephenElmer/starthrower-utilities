// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Western Europe
    /// Ellipsoid: International_1924,  DeltaX: -87,  SigmaX: 3,  DeltaY: -96,  SigmaY: 3,  DeltaZ: -120,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 78,  South: 30,  East: 25,  West: -15
    /// </summary>
    public class European1950WesternEurope : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1950WesternEurope()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -87;
            this.SigmaX = 3;
            this.DeltaY = -96;
            this.SigmaY = 3;
            this.DeltaZ = -120;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 78;
            this.Domain.Left = -15;
            this.Domain.Bottom = 30;
            this.Domain.Right = 25;
        }
    }
}


