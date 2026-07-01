// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_8
    /// NGIA GeoTrans: ARC 1950, Zambia
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -147,  SigmaX: 21,  DeltaY: -74,  SigmaY: 21,  DeltaZ: -283,  SigmaZ: 27,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -1,  South: -24,  East: 40,  West: 15
    /// </summary>
    public class Arc1950Zambia : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Zambia()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -147;
            this.SigmaX = 21;
            this.DeltaY = -74;
            this.SigmaY = 21;
            this.DeltaZ = -283;
            this.SigmaZ = 27;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -1;
            this.Domain.Left = 15;
            this.Domain.Bottom = -24;
            this.Domain.Right = 40;
        }
    }
}


