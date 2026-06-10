// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1983, Alaska
    /// Ellipsoid: GRS_1980,  DeltaX: 0,  SigmaX: 2,  DeltaY: 0,  SigmaY: 2,  DeltaZ: 0,  SigmaZ: 2,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 78,  South: 48,  East: -135,  West: -175
    /// </summary>
    public class Nad1983Alaska : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1983Alaska()
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
            this.Domain.Top = 78;
            this.Domain.Left = -175;
            this.Domain.Bottom = 48;
            this.Domain.Right = -135;
        }
    }
}


