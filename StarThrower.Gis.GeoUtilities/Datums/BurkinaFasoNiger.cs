// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: POINT 58, Burkina Faso and Niger
    /// Ellipsoid: Clarke_1880_RGS,  DeltaX: -106,  SigmaX: 25,  DeltaY: -129,  SigmaY: 25,  DeltaZ: 165,  SigmaZ: 25,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 10,  South: 0,  East: 25,  West: -15
    /// </summary>
    public class BurkinaFasoNiger : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal BurkinaFasoNiger()
        {
            this.Ellipsoid = new Ellipsoids.Clarke1880Rgs();
            this.DeltaX = -106;
            this.SigmaX = 25;
            this.DeltaY = -129;
            this.SigmaY = 25;
            this.DeltaZ = 165;
            this.SigmaZ = 25;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 10;
            this.Domain.Left = -15;
            this.Domain.Bottom = 0;
            this.Domain.Right = 25;
        }
    }
}


