// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NORTH AMERICAN 1927, E. Canada
    /// Ellipsoid: Clarke_1866,  DeltaX: -22,  SigmaX: 6,  DeltaY: 160,  SigmaY: 6,  DeltaZ: 190,  SigmaZ: 3,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 68,  South: 38,  East: -45,  West: -85
    /// </summary>
    public class Nad1927EasternCanada : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Nad1927EasternCanada()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1866();
            this.DeltaX = -22;
            this.SigmaX = 6;
            this.DeltaY = 160;
            this.SigmaY = 6;
            this.DeltaZ = 190;
            this.SigmaZ = 3;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 68;
            this.Domain.Left = -85;
            this.Domain.Bottom = 38;
            this.Domain.Right = -45;
        }
    }
}


