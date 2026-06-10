// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Greenland
    /// Ellipsoid: Clarke_1866,  DeltaX: 11,  SigmaX: 25,  DeltaY: 114,  SigmaY: 25,  DeltaZ: 195,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 81,  South: 74,  East: -56,  West: -74
    /// </summary>
    public class Nad1927Greenland : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Greenland()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 11;
            this.SigmaX = 25;
            this.DeltaY = 114;
            this.SigmaY = 25;
            this.DeltaZ = 195;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 81;
            this.Domain.Left = -74;
            this.Domain.Bottom = 74;
            this.Domain.Right = -56;
        }
    }
}


