// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (CC), Oahu
    /// Ellipsoid: Clarke_1866,  DeltaX: 58,  SigmaX: 10,  DeltaY: -283,  SigmaY: 6,  DeltaZ: -182,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 23,  South: 20,  East: -156,  West: -160
    /// </summary>
    public class HawaiianOahuCc : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianOahuCc()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 58;
            this.SigmaX = 10;
            this.DeltaY = -283;
            this.SigmaY = 6;
            this.DeltaZ = -182;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 23;
            this.Domain.Left = -160;
            this.Domain.Bottom = 20;
            this.Domain.Right = -156;
        }
    }
}


