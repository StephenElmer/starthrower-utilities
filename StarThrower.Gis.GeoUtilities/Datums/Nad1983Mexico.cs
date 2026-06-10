// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Mexico
    /// Ellipsoid: GRS_1980,  DeltaX: 0,  SigmaX: 2,  DeltaY: 0,  SigmaY: 2,  DeltaZ: 0,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 35,  South: 11,  East: -72,  West: -122
    /// </summary>
    public class Nad1983Mexico : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Mexico()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = 0;
            this.SigmaX = 2;
            this.DeltaY = 0;
            this.SigmaY = 2;
            this.DeltaZ = 0;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 35;
            this.Domain.Left = -122;
            this.Domain.Bottom = 11;
            this.Domain.Right = -72;
        }
    }
}


