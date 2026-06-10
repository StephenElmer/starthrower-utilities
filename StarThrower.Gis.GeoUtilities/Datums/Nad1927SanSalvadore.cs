// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, San Salv.
    /// Ellipsoid: Clarke_1866,  DeltaX: 1,  SigmaX: 25,  DeltaY: 140,  SigmaY: 25,  DeltaZ: 165,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 26,  South: 23,  East: -74,  West: -75
    /// </summary>
    public class Nad1927SanSalvadore : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927SanSalvadore()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 1;
            this.SigmaX = 25;
            this.DeltaY = 140;
            this.SigmaY = 25;
            this.DeltaZ = 165;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 26;
            this.Domain.Left = -75;
            this.Domain.Bottom = 23;
            this.Domain.Right = -74;
        }
    }
}


