// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: EUROPEAN 1950, Mean (3 Param)
    /// Ellipsoid: International_1924,  DeltaX: -87,  SigmaX: 3,  DeltaY: -98,  SigmaY: 8,  DeltaZ: -121,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 80,  South: 30,  East: 33,  West: 5
    /// </summary>
    public class European19503Param : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal European19503Param()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -87;
            this.SigmaX = 3;
            this.DeltaY = -98;
            this.SigmaY = 8;
            this.DeltaZ = -121;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 80;
            this.Domain.Left = 5;
            this.Domain.Bottom = 30;
            this.Domain.Right = 33;
        }
    }
}


