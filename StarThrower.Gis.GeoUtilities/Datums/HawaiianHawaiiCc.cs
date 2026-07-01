// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (CC), Hawaii
    /// Ellipsoid: Clarke_1866,  DeltaX: 89,  SigmaX: 25,  DeltaY: -279,  SigmaY: 25,  DeltaZ: -183,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 22,  South: 17,  East: -153,  West: -158
    /// </summary>
    public class HawaiianHawaiiCc : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianHawaiiCc()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 89;
            this.SigmaX = 25;
            this.DeltaY = -279;
            this.SigmaY = 25;
            this.DeltaZ = -183;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 22;
            this.Domain.Left = -158;
            this.Domain.Bottom = 17;
            this.Domain.Right = -153;
        }
    }
}


