// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, NW Terr.
    /// Ellipsoid: Clarke_1866,  DeltaX: 4,  SigmaX: 5,  DeltaY: 159,  SigmaY: 5,  DeltaZ: 188,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 90,  South: 43,  East: -55,  West: -144
    /// </summary>
    public class Nad1927NwTerritory : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927NwTerritory()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 4;
            this.SigmaX = 5;
            this.DeltaY = 159;
            this.SigmaY = 5;
            this.DeltaZ = 188;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 90;
            this.Domain.Left = -144;
            this.Domain.Bottom = 43;
            this.Domain.Right = -55;
        }
    }
}


