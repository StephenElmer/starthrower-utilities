// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_1
    /// NGIA GeoTrans: ADINDAN, Mean
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -166,  SigmaX: 5,  DeltaY: -15,  SigmaY: 5,  DeltaZ: 204,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 31,  South: -5,  East: 55,  West: 15
    /// </summary>
    public class AdindanMean : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanMean()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -166;
            this.SigmaX = 5;
            this.DeltaY = -15;
            this.SigmaY = 5;
            this.DeltaZ = 204;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 31;
            this.Domain.Left = 15;
            this.Domain.Bottom = -5;
            this.Domain.Right = 55;
        }
    }
}


