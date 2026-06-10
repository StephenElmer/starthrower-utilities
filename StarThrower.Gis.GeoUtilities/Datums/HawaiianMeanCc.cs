// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: OLD HAWAIIAN (CC), Mean
    /// Ellipsoid: Clarke_1866,  DeltaX: 61,  SigmaX: 25,  DeltaY: -285,  SigmaY: 20,  DeltaZ: -181,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 17,  East: -153,  West: -164
    /// </summary>
    public class HawaiianMeanCc : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HawaiianMeanCc()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 61;
            this.SigmaX = 25;
            this.DeltaY = -285;
            this.SigmaY = 20;
            this.DeltaZ = -181;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = -164;
            this.Domain.Bottom = 17;
            this.Domain.Right = -153;
        }
    }
}


