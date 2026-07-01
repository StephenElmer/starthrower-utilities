// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_4
    /// NGIA GeoTrans: ARC 1950, Lesotho
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -125,  SigmaX: 3,  DeltaY: -108,  SigmaY: 3,  DeltaZ: -295,  SigmaZ: 8,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -23,  South: -36,  East: 35,  West: 21
    /// </summary>
    public class Arc1950Lesotho : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Lesotho()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -125;
            this.SigmaX = 3;
            this.DeltaY = -108;
            this.SigmaY = 3;
            this.DeltaZ = -295;
            this.SigmaZ = 8;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -23;
            this.Domain.Left = 21;
            this.Domain.Bottom = -36;
            this.Domain.Right = 35;
        }
    }
}


