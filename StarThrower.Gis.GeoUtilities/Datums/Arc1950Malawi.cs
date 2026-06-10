// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_5
    /// NGIA GeoTrans: ARC 1950, Malawi
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -161,  SigmaX: 9,  DeltaY: -73,  SigmaY: 24,  DeltaZ: -317,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -3,  South: -21,  East: 42,  West: 26
    /// </summary>
    public class Arc1950Malawi : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Malawi()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -161;
            this.SigmaX = 9;
            this.DeltaY = -73;
            this.SigmaY = 24;
            this.DeltaZ = -317;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -3;
            this.Domain.Left = 26;
            this.Domain.Bottom = -21;
            this.Domain.Right = 42;
        }
    }
}


