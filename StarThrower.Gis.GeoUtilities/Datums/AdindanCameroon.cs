// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: Adindan_to_WGS_1984_3
    /// NGIA GeoTrans: ADINDAN, Cameroon
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -134,  SigmaX: 25,  DeltaY: -2,  SigmaY: 25,  DeltaZ: 210,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: -4,  East: 23,  West: 3
    /// </summary>
    public class AdindanCameroon : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AdindanCameroon()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -134;
            this.SigmaX = 25;
            this.DeltaY = -2;
            this.SigmaY = 25;
            this.DeltaZ = 210;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = 3;
            this.Domain.Bottom = -4;
            this.Domain.Right = 23;
        }
    }
}


