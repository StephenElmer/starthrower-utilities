// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_9
    /// NGIA GeoTrans: ARC 1950, Zimbabwe
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -142,  SigmaX: 5,  DeltaY: -96,  SigmaY: 8,  DeltaZ: -293,  SigmaZ: 11,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -9,  South: -29,  East: 39,  West: 19
    /// </summary>
    public class Arc1950Zimbabwe : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Zimbabwe()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -142;
            this.SigmaX = 5;
            this.DeltaY = -96;
            this.SigmaY = 8;
            this.DeltaZ = -293;
            this.SigmaZ = 11;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -9;
            this.Domain.Left = 19;
            this.Domain.Bottom = -29;
            this.Domain.Right = 39;
        }
    }
}


