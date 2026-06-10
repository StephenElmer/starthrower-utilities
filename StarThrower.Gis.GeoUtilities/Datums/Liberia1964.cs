// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: LIBERIA 1964
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -90,  SigmaX: 15,  DeltaY: 40,  SigmaY: 15,  DeltaZ: 88,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 14,  South: -1,  East: -1,  West: -17
    /// </summary>
    public class Liberia1964 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Liberia1964()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -90;
            this.SigmaX = 15;
            this.DeltaY = 40;
            this.SigmaY = 15;
            this.DeltaZ = 88;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 14;
            this.Domain.Left = -17;
            this.Domain.Bottom = -1;
            this.Domain.Right = -1;
        }
    }
}


