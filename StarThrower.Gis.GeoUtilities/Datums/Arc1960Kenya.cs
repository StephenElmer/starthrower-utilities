// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1960_To_WGS_1984_2
    /// NGIA GeoTrans: ARC 1960, Kenya
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -157,  SigmaX: 4,  DeltaY: -2,  SigmaY: 3,  DeltaZ: -299,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 8,  South: -11,  East: 47,  West: 28
    /// </summary>
    public class Arc1960Kenya : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1960Kenya()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -157;
            this.SigmaX = 4;
            this.DeltaY = -2;
            this.SigmaY = 3;
            this.DeltaZ = -299;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 8;
            this.Domain.Left = 28;
            this.Domain.Bottom = -11;
            this.Domain.Right = 47;
        }
    }
}


