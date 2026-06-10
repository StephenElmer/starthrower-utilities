// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: NAPARIMA, Trinidad and Tobago
    /// Ellipsoid: International_1924,  DeltaX: -10,  SigmaX: 15,  DeltaY: 375,  SigmaY: 15,  DeltaZ: 165,  SigmaZ: 15,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 13,  South: 8,  East: -59,  West: -64
    /// </summary>
    public class NaparimaTrinidadTobago : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal NaparimaTrinidadTobago()
        {
            this.Ellipsoid = new Ellipsoids.International1924();
            this.DeltaX = -10;
            this.SigmaX = 15;
            this.DeltaY = 375;
            this.SigmaY = 15;
            this.DeltaZ = 165;
            this.SigmaZ = 15;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 13;
            this.Domain.Left = -64;
            this.Domain.Bottom = 8;
            this.Domain.Right = -59;
        }
    }
}


