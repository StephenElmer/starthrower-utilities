// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: SAPPER HILL 1943, E Falkland Is
    /// Ellipsoid: International_1924,  DeltaX: -355,  SigmaX: 1,  DeltaY: 21,  SigmaY: 1,  DeltaZ: 72,  SigmaZ: 1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -50,  South: -54,  East: -56,  West: -61
    /// </summary>
    public class EFalklandIsland1943 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal EFalklandIsland1943()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -355;
            this.SigmaX = 1;
            this.DeltaY = 21;
            this.SigmaY = 1;
            this.DeltaZ = 72;
            this.SigmaZ = 1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -50;
            this.Domain.Left = -61;
            this.Domain.Bottom = -54;
            this.Domain.Right = -56;
        }
    }
}


