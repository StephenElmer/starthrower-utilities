// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1979
    /// Ellipsoid: International_1924,  DeltaX: -86,  SigmaX: 3,  DeltaY: -98,  SigmaY: 3,  DeltaZ: -119,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 80,  South: 30,  East: 24,  West: -15
    /// </summary>
    public class European1979 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European1979()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -86;
            this.SigmaX = 3;
            this.DeltaY = -98;
            this.SigmaY = 3;
            this.DeltaZ = -119;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 80;
            this.Domain.Left = -15;
            this.Domain.Bottom = 30;
            this.Domain.Right = 24;
        }
    }
}


