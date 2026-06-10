// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_1
    /// NGIA GeoTrans: ARC 1950, Mean
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -143,  SigmaX: 20,  DeltaY: -90,  SigmaY: 33,  DeltaZ: -294,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 10,  South: -36,  East: 42,  West: 4
    /// </summary>
    public class Arc1950Mean : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Mean()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -143;
            this.SigmaX = 20;
            this.DeltaY = -90;
            this.SigmaY = 33;
            this.DeltaZ = -294;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 10;
            this.Domain.Left = 4;
            this.Domain.Bottom = -36;
            this.Domain.Right = 42;
        }
    }
}


