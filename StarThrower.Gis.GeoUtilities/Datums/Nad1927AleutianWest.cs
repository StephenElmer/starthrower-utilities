// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Aleutian w
    /// Ellipsoid: Clarke_1866,  DeltaX: 2,  SigmaX: 10,  DeltaY: 204,  SigmaY: 10,  DeltaZ: 105,  SigmaZ: 10,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 58,  South: 50,  East: 180,  West: 169
    /// </summary>
    public class Nad1927AleutianWest : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927AleutianWest()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = 2;
            this.SigmaX = 10;
            this.DeltaY = 204;
            this.SigmaY = 10;
            this.DeltaZ = 105;
            this.SigmaZ = 10;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 58;
            this.Domain.Left = 169;
            this.Domain.Bottom = 50;
            this.Domain.Right = 180;
        }
    }
}


