// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: PROV. S AMERICAN 1956, Venez
    /// Ellipsoid: International_1924,  DeltaX: -295,  SigmaX: 9,  DeltaY: 173,  SigmaY: 14,  DeltaZ: -371,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 18,  South: -5,  East: -54,  West: -79
    /// </summary>
    public class SAmericanVenez1956 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal SAmericanVenez1956()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -295;
            this.SigmaX = 9;
            this.DeltaY = 173;
            this.SigmaY = 14;
            this.DeltaZ = -371;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 18;
            this.Domain.Left = -79;
            this.Domain.Bottom = -5;
            this.Domain.Right = -54;
        }
    }
}


