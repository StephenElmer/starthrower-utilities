// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Canada
    /// Ellipsoid: Clarke_1866,  DeltaX: -10,  SigmaX: 15,  DeltaY: 158,  SigmaY: 11,  DeltaZ: 187,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 90,  South: 36,  East: -50,  West: -150
    /// </summary>
    public class Nad1927Canada : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Canada()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -10;
            this.SigmaX = 15;
            this.DeltaY = 158;
            this.SigmaY = 11;
            this.DeltaZ = 187;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 90;
            this.Domain.Left = -150;
            this.Domain.Bottom = 36;
            this.Domain.Right = -50;
        }
    }
}


