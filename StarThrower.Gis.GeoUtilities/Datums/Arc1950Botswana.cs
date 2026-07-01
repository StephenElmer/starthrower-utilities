// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Arc_1950_To_WGS_1984_2
    /// NGIA GeoTrans: ARC 1950, Botswana
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -138,  SigmaX: 3,  DeltaY: -105,  SigmaY: 5,  DeltaZ: -289,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -13,  South: -33,  East: 36,  West: 13
    /// </summary>
    public class Arc1950Botswana : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Arc1950Botswana()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -138;
            this.SigmaX = 3;
            this.DeltaY = -105;
            this.SigmaY = 5;
            this.DeltaZ = -289;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -13;
            this.Domain.Left = 13;
            this.Domain.Bottom = -33;
            this.Domain.Right = 36;
        }
    }
}


