// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Hawaii
    /// Ellipsoid: GRS_1980,  DeltaX: 1,  SigmaX: 2,  DeltaY: 1,  SigmaY: 2,  DeltaZ: -1,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 24,  South: 17,  East: -153,  West: -164
    /// </summary>
    public class Nad1983Hawaii : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Hawaii()
        {
            this.Ellipsoid = new Ellipsoids.Grs1980();
            this.DeltaX = 1;
            this.SigmaX = 2;
            this.DeltaY = 1;
            this.SigmaY = 2;
            this.DeltaZ = -1;
            this.SigmaZ = 2;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 24;
            this.Domain.Left = -164;
            this.Domain.Bottom = 17;
            this.Domain.Right = -153;
        }
    }
}


