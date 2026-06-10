// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: HJORSEY 1955, Iceland
    /// Ellipsoid: International_1924,  DeltaX: -73,  SigmaX: 3,  DeltaY: 46,  SigmaY: 3,  DeltaZ: -86,  SigmaZ: 6,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 69,  South: 61,  East: -11,  West: -27
    /// </summary>
    public class HjorseyIceland1955 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal HjorseyIceland1955()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -73;
            this.SigmaX = 3;
            this.DeltaY = 46;
            this.SigmaY = 3;
            this.DeltaZ = -86;
            this.SigmaZ = 6;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 69;
            this.Domain.Left = -27;
            this.Domain.Bottom = 61;
            this.Domain.Right = -11;
        }
    }
}


