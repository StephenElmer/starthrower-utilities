// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, S Chile
    /// Ellipsoid: International_1924,  DeltaX: -305,  SigmaX: 20,  DeltaY: 243,  SigmaY: 20,  DeltaZ: -442,  SigmaZ: 20,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: -20,  South: -64,  East: -60,  West: -83
    /// </summary>
    public class SAmericanSouthChile1956 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanSouthChile1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -305;
            this.SigmaX = 20;
            this.DeltaY = 243;
            this.SigmaY = 20;
            this.DeltaZ = -442;
            this.SigmaZ = 20;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = -20;
            this.Domain.Left = -83;
            this.Domain.Bottom = -64;
            this.Domain.Right = -60;
        }
    }
}


