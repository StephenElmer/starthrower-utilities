// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (CC), Kauai
    /// Ellipsoid: Clarke_1866,  DeltaX: 45,  SigmaX: 20,  DeltaY: -290,  SigmaY: 20,  DeltaZ: -172,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 20,  East: -158,  West: -161
    /// </summary>
    public class HawaiianKauaiCc : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianKauaiCc()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 45;
            this.SigmaX = 20;
            this.DeltaY = -290;
            this.SigmaY = 20;
            this.DeltaZ = -172;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = -161;
            this.Domain.Bottom = 20;
            this.Domain.Right = -158;
        }
    }
}


