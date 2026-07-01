// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_6
    /// NGIA GeoTrans: ARC 1950, Swaziland
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -134,  SigmaX: 15,  DeltaY: -105,  SigmaY: 15,  DeltaZ: -295,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -20,  South: -33,  East: 40,  West: 25
    /// </summary>
    public class Arc1950Swaziland : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Swaziland()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -134;
            this.SigmaX = 15;
            this.DeltaY = -105;
            this.SigmaY = 15;
            this.DeltaZ = -295;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -20;
            this.Domain.Left = 25;
            this.Domain.Bottom = -33;
            this.Domain.Right = 40;
        }
    }
}


