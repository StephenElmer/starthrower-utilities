// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: VOIROL 1874, Algeria
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -73,  SigmaX: -1,  DeltaY: -247,  SigmaY: -1,  DeltaZ: 227,  SigmaZ: -1,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 43,  South: 13,  East: 18,  West: -15
    /// </summary>
    public class Algeria1874 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Algeria1874()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -73;
            this.SigmaX = -1;
            this.DeltaY = -247;
            this.SigmaY = -1;
            this.DeltaZ = 227;
            this.SigmaZ = -1;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 43;
            this.Domain.Left = -15;
            this.Domain.Bottom = 13;
            this.Domain.Right = 18;
        }
    }
}


