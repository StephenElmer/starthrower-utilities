// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_3
    /// NGIA GeoTrans: ARC 1950, Burundi
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -153,  SigmaX: 20,  DeltaY: -5,  SigmaY: 20,  DeltaZ: -292,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 4,  South: -11,  East: 37,  West: 21
    /// </summary>
    public class Arc1950Burundi : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Burundi()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -153;
            this.SigmaX = 20;
            this.DeltaY = -5;
            this.SigmaY = 20;
            this.DeltaZ = -292;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 4;
            this.Domain.Left = 21;
            this.Domain.Bottom = -11;
            this.Domain.Right = 37;
        }
    }
}


