// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: TANANARIVE OBSERVATORY 1925
    /// Ellipsoid: International_1924,  DeltaX: -189,  SigmaX: -1,  DeltaY: -242,  SigmaY: -1,  DeltaZ: -91,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -8,  South: -34,  East: 53,  West: 40
    /// </summary>
    public class TananariveObservatory1925 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal TananariveObservatory1925()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -189;
            this.SigmaX = -1;
            this.DeltaY = -242;
            this.SigmaY = -1;
            this.DeltaZ = -91;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -8;
            this.Domain.Left = 40;
            this.Domain.Bottom = -34;
            this.Domain.Right = 53;
        }
    }
}


