// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: AYABELLE LIGHTHOUSE, Djibouti
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -79,  SigmaX: 25,  DeltaY: -129,  SigmaY: 25,  DeltaZ: 145,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 20,  South: 5,  East: 49,  West: 36
    /// </summary>
    public class AyabelleLighthouseDjibouti : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal AyabelleLighthouseDjibouti()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -79;
            this.SigmaX = 25;
            this.DeltaY = -129;
            this.SigmaY = 25;
            this.DeltaZ = 145;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 20;
            this.Domain.Left = 36;
            this.Domain.Bottom = 5;
            this.Domain.Right = 49;
        }
    }
}


