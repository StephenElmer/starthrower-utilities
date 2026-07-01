// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: ISTS 061 ASTRO 1968, S Georgia
    /// Ellipsoid: International_1924,  DeltaX: -794,  SigmaX: 25,  DeltaY: 119,  SigmaY: 25,  DeltaZ: -298,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -52,  South: -56,  East: -34,  West: -38
    /// </summary>
    public class SouthGeorgia1968 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SouthGeorgia1968()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -794;
            this.SigmaX = 25;
            this.DeltaY = 119;
            this.SigmaY = 25;
            this.DeltaZ = -298;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -52;
            this.Domain.Left = -38;
            this.Domain.Bottom = -56;
            this.Domain.Right = -34;
        }
    }
}


