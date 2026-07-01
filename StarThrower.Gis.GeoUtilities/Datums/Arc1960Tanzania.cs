// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1960_To_WGS_1984_3
    /// NGIA GeoTrans: ARC 1960, Tanzania
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -175,  SigmaX: 6,  DeltaY: -23,  SigmaY: 9,  DeltaZ: -303,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 5,  South: -18,  East: 47,  West: 23
    /// </summary>
    public class Arc1960Tanzania : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1960Tanzania()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -175;
            this.SigmaX = 6;
            this.DeltaY = -23;
            this.SigmaY = 9;
            this.DeltaZ = -303;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 5;
            this.Domain.Left = 23;
            this.Domain.Bottom = -18;
            this.Domain.Right = 47;
        }
    }
}


