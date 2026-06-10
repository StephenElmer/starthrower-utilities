// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Bahamas
    /// Ellipsoid: Clarke_1866,  DeltaX: -4,  SigmaX: 5,  DeltaY: 154,  SigmaY: 3,  DeltaZ: 178,  SigmaZ: 5,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 29,  South: 19,  East: -71,  West: -83
    /// </summary>
    public class Nad1927Bahamas : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Bahamas()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -4;
            this.SigmaX = 5;
            this.DeltaY = 154;
            this.SigmaY = 3;
            this.DeltaZ = 178;
            this.SigmaZ = 5;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 29;
            this.Domain.Left = -83;
            this.Domain.Bottom = 19;
            this.Domain.Right = -71;
        }
    }
}


