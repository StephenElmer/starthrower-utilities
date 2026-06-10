// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Canal Zone
    /// Ellipsoid: Clarke_1866,  DeltaX: 0,  SigmaX: 20,  DeltaY: 125,  SigmaY: 20,  DeltaZ: 201,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 15,  South: 3,  East: -74,  West: -86
    /// </summary>
    public class Nad1927CanalZone : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927CanalZone()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 0;
            this.SigmaX = 20;
            this.DeltaY = 125;
            this.SigmaY = 20;
            this.DeltaZ = 201;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 15;
            this.Domain.Left = -86;
            this.Domain.Bottom = 3;
            this.Domain.Right = -74;
        }
    }
}


