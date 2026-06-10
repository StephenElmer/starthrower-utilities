// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_7
    /// NGIA GeoTrans: ARC 1950, Zaire
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -169,  SigmaX: 25,  DeltaY: -19,  SigmaY: 25,  DeltaZ: -278,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 10,  South: -21,  East: 38,  West: 4
    /// </summary>
    public class Arc1950Zaire : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Zaire()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -169;
            this.SigmaX = 25;
            this.DeltaY = -19;
            this.SigmaY = 25;
            this.DeltaZ = -278;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 10;
            this.Domain.Left = 4;
            this.Domain.Bottom = -21;
            this.Domain.Right = 38;
        }
    }
}


