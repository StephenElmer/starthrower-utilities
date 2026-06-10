// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, Yukon
    /// Ellipsoid: Clarke_1866,  DeltaX: -7,  SigmaX: 5,  DeltaY: 139,  SigmaY: 8,  DeltaZ: 181,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 75,  South: 53,  East: -117,  West: -147
    /// </summary>
    public class Nad1927Yukon : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927Yukon()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -7;
            this.SigmaX = 5;
            this.DeltaY = 139;
            this.SigmaY = 8;
            this.DeltaZ = 181;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 75;
            this.Domain.Left = -147;
            this.Domain.Bottom = 53;
            this.Domain.Right = -117;
        }
    }
}


