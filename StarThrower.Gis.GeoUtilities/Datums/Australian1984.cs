// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: AUSTRALIAN GEODETIC 1984
    /// Ellipsoid: Australian,  DeltaX: -134,  SigmaX: 2,  DeltaY: -48,  SigmaY: 2,  DeltaZ: 149,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -4,  South: -46,  East: 161,  West: 109
    /// </summary>
    public class Australian1984 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Australian1984()
        {
            this.Ellipsoid = new Ellipsoids.Australian();
            this.DeltaX = -134;
            this.SigmaX = 2;
            this.DeltaY = -48;
            this.SigmaY = 2;
            this.DeltaZ = 149;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -4;
            this.Domain.Left = 109;
            this.Domain.Bottom = -46;
            this.Domain.Right = 161;
        }
    }
}


