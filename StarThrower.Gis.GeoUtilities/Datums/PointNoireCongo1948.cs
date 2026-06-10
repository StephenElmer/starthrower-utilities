// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: POINT NOIRE 1948, Congo
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -148,  SigmaX: 25,  DeltaY: 51,  SigmaY: 25,  DeltaZ: -291,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 10,  South: -11,  East: 25,  West: 5
    /// </summary>
    public class PointNoireCongo1948 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal PointNoireCongo1948()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -148;
            this.SigmaX = 25;
            this.DeltaY = 51;
            this.SigmaY = 25;
            this.DeltaZ = -291;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 10;
            this.Domain.Left = 5;
            this.Domain.Bottom = -11;
            this.Domain.Right = 25;
        }
    }
}


