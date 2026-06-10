// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: MINNA, Cameroon
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -81,  SigmaX: 25,  DeltaY: -84,  SigmaY: 25,  DeltaZ: 115,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 19,  South: -4,  East: 23,  West: 3
    /// </summary>
    public class MinnaCameroon : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal MinnaCameroon()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -81;
            this.SigmaX = 25;
            this.DeltaY = -84;
            this.SigmaY = 25;
            this.DeltaZ = 115;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 19;
            this.Domain.Left = 3;
            this.Domain.Bottom = -4;
            this.Domain.Right = 23;
        }
    }
}


